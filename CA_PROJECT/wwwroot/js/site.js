function Post(url, value) {
    return $.ajax({
        type: "POST",
        contentType: "application/json",
        url: url,
        data: JSON.stringify({ Value: value }),
        success: function (response) {
            var result = JSON.parse(response);
            console.log("success in post ajax" + result);
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
            var result = JSON.parse(response);
            console.log("success in get ajax" + result);
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
        data: JSON.stringify({ Value: value }) ,
        success: function (response) {
            var result = JSON.parse(response);
            console.log("success in put ajax" + result);
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
            var result = JSON.parse(response);
            console.log("success in delete ajax" + result);
            return Promise.resolve(result);
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

    $("#loginBtn").click(function () {
        var username = $("#username").val();
        var psw = $("#psw").val();
        if (uname.length === 0 || pwd.length === 0) {
            $("errmsg").html("All fields are required.");
            return;
        }

        $("#hashPwd").val(CryptoJS.SHA256(pwd).toString());
        $("#pwd").val("");

        $("#loginForm").submit();
    });

})
