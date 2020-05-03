/// <reference path="jquery-3.4.1.min.js" />
function loadNav() {
    $.ajax({
        url:'/Home/GetNav', 
        contentType: "application/html",
        success: function (result) {
            $('.mynav').html(result);
        }
    });
}