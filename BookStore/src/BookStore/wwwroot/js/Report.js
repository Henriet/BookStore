$(document).ready(function () {

    var viewModel = {
        items: ko.observableArray([])
    };

    viewModel.GetCategories = ko.computed(function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: "api/Report",
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    self.items.push({ Name: data[i].CategoryName, Count: data[i].CountOfBooks });
                }

                return data;
            },
            error: function () {
                alert("Something went wrong :(");
            }
        });
    }, viewModel);
    ko.applyBindings(viewModel);
});