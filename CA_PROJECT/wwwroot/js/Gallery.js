badges = 0;
$(document).ready(function () {

    $("#SearchInput").on("keydown", function (event) {
        var code = event.keyCode;
        var value = $(this).val().toLowerCase();
        if (code == "13") {
            
        }
    });

    $("#SearchInput").on("change", function () {
        var value = $(this).val();
        if (value.length == 0) {
            $("form").submit();
        }
    })

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

$(".AddCart").click(function () {
    var productId = $(this).parent().next().val();
    Post("/Gallery/Addtocart", { ProductId: productId })
        .then(function (response) {
            $("span[class='badge']").html(response);
        })
        .catch(function (err) {
            console.log("error", err)
        })
})

$('.clear').click(function () {
    itemCount = 0;
    $('#itemCount').html('').css('display', 'none');
    $('#cartItems').html('');
});

$("#ShoppingCart").click(function () {
    window.location.href = "../Cart";
})