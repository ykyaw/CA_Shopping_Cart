$(document).ready(function () {
    $("#logout").on("click", function () {
        Get("/Logout")
            .then(function (response) {
                if (response) {
                    window.location.href = "/Login";
                } else {
                    alert("something wrong in server");
                }
            })
            .catch(function (err) {
                alert("something wrong in server");
            })
    })

})
