function Post(url, value) {
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
    Get("/Purchases")
        .then(function (response) {
            var result = JSON.parse(response);
            console.log("result in get purchase", result);
            var purchaseDetail = "";
            for (var i = 0; i < result.Value.length; i++) {
                purchaseDetail += `<div class="purchase-row">
                    <div class="product">
                        <img class="product-img" src="assets/1586316169(1).jpg" />
                        <div>product name</div>
                        <div>product description</div>
                        <div id="download" class="download-button">Download</div>
                    </div>
                    <div class="purchase-detail">
                        <table id="purchase-detail-table">
                            <tr>
                                <td>Purchased On:</td>
                                <td>${result.Value[i].PurchaseDate}</td>
                            </tr>
                            <tr>
                                <td>Quantity:</td>
                                <td>${result.Value[i].Quantity}</td>
                            </tr>
                           
                        </table>
                    </div>
                </div>`;
            }
            $("#purchases").html(purchaseDetail);
        })
        .catch(function (err) {
            console.log("error in get purchases: " ,JSON.stringify(err));
        })

})
