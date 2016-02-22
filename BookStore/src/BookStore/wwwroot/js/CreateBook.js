$(document).ready(function () {
    $("#submit").click(function () {
        var name = $('#Name').val();
        var isbn = $('#ISBN').val();
        var author = $('#Author').val();
        var data = JSON.stringify({ Name: name, ISBN: isbn, Author: author });

        $.ajax({
            type: "POST",
            url: window.location.protocol + "//" + window.location.host + "/api/Books",
            data: data,
            contentType: "application/json",
            success: function () {
                window.location.replace(window.location.protocol + "//" + window.location.host + "/Books");
            },
            error: function () {
                alert("Something went wrong :(");
            }
        });
    });
});