﻿function Post(url, value) {
    return $.ajax({
        type: "POST",
        contentType: "application/json",
        url: url,
        data: JSON.stringify({ Value: value }),
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
        data: JSON.stringify({ Value: value }),
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
    Get("/cartList")
        .then(function (response) {
            var result = JSON.parse(response);
            console.log("success", result);
            for (var i = 0; i < result.length; i++)
            {
                console.log(result[i]);
            }

            
        })
        .catch(function (err) {
            console.log("error in get purchases: ", JSON.stringify(err));
        })

})
