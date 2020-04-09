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
   // Post("/login", { username: username, psw: psw })
