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


function changeQty(e) {
    //alert("qty is " + e.value);
    var quantity = Number(e.value);
    var cartId = e.nextElementSibling.value;
    Post("/changeQty", { Id: cartId, Quantity: Number(e.value) })
        .then(function (response) {
            var result = JSON.parse(response);
            console.log("success", result);
            if (quantity <= 0) {
                var parent = e.parentNode.parentNode.parentNode;
                parent.innerHTML = "";
                return;
            }
        })
        .catch(function (err) {
            console.log("err", err);
        })

    $("totalBtn").click(function (cart) {
        
        var quantity = Number(e.value);
        var price = e.nextElementSibling.value;
        alert("Total: ",total)
    });

    public decimal GetTotal()
    {
        ShoppingCartId = GetCartId();
        // Multiply product price by quantity of that product to get        
        // the current price for each of those products in the cart.  
        // Sum all product price totals to get the cart total.   
        decimal ? total = decimal.Zero;
        total = (decimal?)(from cartItems in _db.ShoppingCartItems
        where cartItems.CartId == ShoppingCartId
        select(int ?)cartItems.Quantity *
            cartItems.Product.UnitPrice).Sum();
        return total ?? decimal.Zero;
    }
    

}

    

//})
//$("#changeQty").click(function () {
//    var productId = $(this).next().val(); 
//    alert("ProductId is" + productId);
//});



