function Post(url, value) {
    return $.ajax({
        type: "POST",
        contentType: "application/json",
        url: url,
        data: JSON.stringify(value),
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
    Get("/GetGalleries")
        .then(function (response) {
            var result = JSON.parse(response); //How to link the response with "Gallery" user click?
            console.log("result in get purchase", result);

        })
        .catch(function (err) {
            console.log("error in get gallery: ", JSON.stringify(err));
        })


    $("#SearchInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#ProductTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
})

var itemCount = 0;
$(".AddCart").click(function () {
    itemCount++;
    $('#itemCount').html(itemCount).css('display', 'block');
    var pos = $(this).parent().next().val();
    alert("Product added to cart is " + pos)
    Post("/Gallery/Addtocart", { ProductId: pos })
        .then(function (response) {
            console.log("success", response)
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
    alert("Will jump to ShoppingCart page")
    window.location.href = "ShoppingCart";
})
/*
$(document).ready(function () {

    $('#AddCart').click(function () {
        var pos = $(this).next().find('.productId').val();
        alert(pos)
        });
    });

    Get("/GetGalleries")
    .then(function (response) {
        var result = JSON.parse(response); //How to link the response with "Gallery" user click?
        console.log("result in get purchase", result);
    })
    .catch(function (err) {
        console.log("error in get gallery: ", JSON.stringify(err));
    })

    $("#SearchInput").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("#ProductTable tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
    });
});
*/



/*
$(document).ready(function () {
    var productId = "123123";;
    Post("/addToCart", { ProductId: productId, UserId: " user1" })
        .then(function (reponse) {
            var result = Json.parse(response);
        })
        .catch(function (err) {
})
*/




//$(function() {
//  $("#search").on("keyup", function() {
//    $(".users").html("");
//    var val = $.trim(this.value);
//    if (val) {
//      val = val.toLowerCase();
//      $.each(usersArray, function(_,obj) {
//       // console.log(val,obj.name.toLowerCase().indexOf(val),obj)
//        if (obj.name.toLowerCase().indexOf(val) != -1) {
//          $(".users").append('<div class="user-card"><span class="user-info">'+obj.name+'</span><br/><img class="user-image" src="'+obj.image+'"/></div>');
//        }
//      });
//    }
//    $(".not-found").toggle($(".users").find("img").length==0);
//  });
//});