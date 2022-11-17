// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.  $(document).ready(() =>

// ------------------------------------------ LoadData in Product ----------------------------------

//$(document).ready(function () {
//    console.log("ready!");
//    LoadData();
//});



function LoadData () {

    

        $.ajax({
           url: "/Products/GetProducts",
           async: true,
            success: function (data) {
                console.log(data);
                $('tbody').empty();


                for (var i = 0; i < data.length; i++) {
                    $('tbody').append(`<tr>
                        <td>${data[i].productId}</td>
                        <td>${data[i].name}</td>
                        <td>${data[i].quantity}</td>
                        <td>${data[i].price}</td>
                        <td>
                          <button class='my-3' data-bs-toggle='modal'
                            data-bs-target='#UpdateProductModal' > <i class='fa fas fa-edit'></i>
                        </button>
                        </td>
                        </tr>
               `)
                }
            },
            error: function (er) {
                console.log(er);
            }
        });
     };










// ------------------------------------------ Add Product ----------------------------------

$(function () {
    $("#BtnFillTable").click(function () {

        var Product = {};
        Product.Name = $("#Name").val();
        Product.Quantity = $("#Quantity").val();
        Product.Price = $("#Price").val();
        console.log(Product);
        console.log("the Fun work");

        $.ajax({
            method: "post",
            url: '/Products/AddProduct',
            data:Product,
            dataType: "json",
            success: function () {
                alert("Data has been added successfully.");

                   LoadData();
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
        return false;


    });
});