function Post(url, value) {
    return $.ajax({
        type: "POST",
        contentType: "application/json",
        url: url,
        data: JSON.stringify( value ),
        success: function (response) {
            return Promise.resolve(response);
        },
        error: function (response) {
            var result = JSON.parse(response.responseText);
            console.log("error in post ajax" + result);
            return Promise.reject(response);
        }
    });
}

function Get(url) {
    return $.ajax({
        type: "GET",
        contentType: "application/json",
        url: url,
        success: function (response) {
            return Promise.resolve(response);
        },
        error: function (response) {
            var result = JSON.parse(response.responseText);
            console.log("error in get ajax" + result);
            return Promise.reject(response);
        }
    });
}

function Put(url, value) {
    return $.ajax({
        type: "PUT",
        contentType: "application/json",
        url: url,
        data: JSON.stringify(value),
        success: function (response) {
            return Promise.resolve(response);
        },
        error: function (response) {
            var result = JSON.parse(response.responseText);
            console.log("error in put ajax" + result);
            return Promise.reject(response);
        }
    });
}

function Delete(url) {
    return $.ajax({
        type: "DELETE",
        contentType: "application/json",
        url: url,
        success: function (response) {
            return Promise.resolve(response);
        },
        error: function (err) {
            console.log(err);
            //var result = JSON.parse(response.responseText);
            //console.log("error in delete ajax: " + JSON.stringify(result));
            return Promise.reject(err);
        }
    });
}

$(document).ready(function () {

    $("#loginBtn").on("click", function (e) {
        e.preventDefault();
        var username = $("#uname").val();
        var password = $("#pwd").val();
        $("#hashPwd").val(CryptoJS.SHA256(password).toString());
        var hashPwd = $("#hashPwd").val();


        if (username.length == 0 || password.length == 0) {
            $("#errmsg").html("Both Username and Password are required.");
            return;
        }

        Post("/Login/Verify", { Username: username, Password: hashPwd })
            .then(function (response) {
                var result = JSON.parse(response);
                console.log(result);
                if (result.ErrMsg == null) {
                    window.location.replace(result.Value);
                    //redirect page to gallery page
                 //   location.href="~/Views/Gallery)"
                } else {
                    $("#errmsg").html(result.ErrMsg);
                }
            })
            .catch(function (err) {
                console.log("err",err)
            })
    });

        //$("#loginForm").submit();
});

