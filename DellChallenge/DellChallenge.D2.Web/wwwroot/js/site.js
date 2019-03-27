// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(".btnDelete").click(function () {
    var url = this.getAttribute("deleteurl");

    $.post(url, function (result) {
        if (result.ok) {
            window.location.href = result.redirectUrl;
        }
    });

});