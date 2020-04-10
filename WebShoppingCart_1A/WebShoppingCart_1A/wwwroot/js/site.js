// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("input").on("click", function () {
        //alert("click the add to cart")
        var productId = $(this).parent().next().val();
        $.ajax
        
    })
})
    //$("LoginToAcc").click(function (e) {
    //    var str1 = "1";
    //    var str2 = "2";
    //    $.ajax({
    //        type: "POST",
    //        contenttype: "application/json",
    //        url: "/Home/LoginToAcc",
    //        data: { a: str1, b: str2 },
    //        success: function (response) {

    //        },
    //        error: function (err) {

    //        }
    //    })
    //}
        

        