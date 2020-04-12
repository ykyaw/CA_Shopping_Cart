
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

                } else {
                    $("#errmsg").html(result.ErrMsg);
                }
            })
            .catch(function (err) {
                console.log("err",err)
            })
    });
});

