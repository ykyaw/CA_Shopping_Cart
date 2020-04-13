function changeQty(e) {
    //alert("qty is " + e.value);
    var quantity = Number(e.value);
    var cartId = e.nextElementSibling.value;
    Post("/changeQty", { Id: cartId, Quantity: Number(e.value) })
        .then(function (response) {
            var result = JSON.parse(response);
            console.log("success", result);
            if (!result.Value) {
                e.value = --quantity;
                alert("someting wrong in server");
                return;
            }
            var totalamount = 0
            var cartLines = $(".cartLine");
            for (var i = 0; i < cartLines.length; i++) {
                console.log("line", cartLines[i]);
                var price = $(cartLines[i]).find(".price").text()
                var qty = $(cartLines[i]).find(".quantity").val();
                var subtotal = Number(price) * Number(qty);
                if (!Number.isNaN(subtotal)) {
                    totalamount += subtotal;
                }
                $(cartLines[i]).find(".subtotal").text(subtotal);
                $("#total").text(totalamount);
            }
            if (quantity <= 0) {
                var parent = e.parentNode.parentNode.parentNode;
                parent.innerHTML = "";
                return;
            }
        })
        .catch(function (err) {
            console.log("err", err);
        })
}

$(document).ready(function () {
    $("#checkout").on("click", function () {
        var $table = $("table");
        if ($table.length == 0) {
            alert("there is no item in your cart");
            return;
        }
        Get("/Cart/Checkout")
            .then(function (response) {
                if (response) {
                    window.location.href = "../MyPurchase";
                } else {
                    alert("something wrong in server");
                }
            })
            .catch(function (err) {
                console.error(err);
                alert("something wrong in server");
            })
    })
})
