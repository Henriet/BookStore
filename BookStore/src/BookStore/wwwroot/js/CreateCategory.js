$(document).ready(function () {
    $("#submit").click(function () {
        var name = $('#Name').val();
        console.log(name);
        $.ajax({
            type: "POST",
            url: window.location.protocol + "//" + window.location.host + "/api/Categories",
            data: JSON.stringify(name),
            contentType: "application/json",
            success: function () {
                window.location.replace(window.location.protocol + "//" + window.location.host + "/Categories");
            },
            error: function () {
                alert("Something went wrong :(");
            }
        });
    });
});