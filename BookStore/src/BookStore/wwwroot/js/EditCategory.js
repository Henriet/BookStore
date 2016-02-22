$(document).ready(function () {

    var viewModel = {
        Name: ko.observable(''),
        CreationDate: ko.observable(''),
        Books : ko.observableArray([]),
        Id: ko.observable('')
    };

    viewModel.UploadData = ko.computed(function () {
        var self = this;
        var id = $('#Id').val();
        $.ajax({
            type: "GET",
            url: window.location.protocol + "//" + window.location.host + "/api/Categories/" + id,

            success: function(data) {
                self.Name(data.Name);
                self.CreationDate(data.CreationDate);
                self.Id(data.Id);

                for (var i = 0; i < data.length; i++) {
                    self.books.push({ Name: data[i].Name, Id: data[i].Id });
                }
            },
            error: function() {
                alert("Something went wrong :(");
            }
        });
    }, viewModel);


    viewModel.Update = function () {
            var self = this;
            var data = JSON.stringify({ Id: self.Id(), Name: self.Name() });
            console.log(data);
            $.ajax({
                type: "PUT",
                url: window.location.protocol + "//" + window.location.host + "/api/Categories",
                data: data,
                contentType: "application/json",
                success: function () {
                    window.location.replace(window.location.protocol + "//" + window.location.host + "/Categories");
                },
                error: function () {
                    alert("Something went wrong :(");
                }
            });
        };


    ko.applyBindings(viewModel);
});