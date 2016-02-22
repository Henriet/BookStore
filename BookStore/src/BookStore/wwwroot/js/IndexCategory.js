$(document).ready(function () {

    var viewModel = {
        items: ko.observableArray([])
    };

    viewModel.GetCategories = ko.computed(function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: "api/Categories",
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    self.items.push({ Name: data[i].Name, Id: data[i].Id, CreationDate: data[i].CreationDate });
                }
                return data;
            },
            error: function () {
                alert("Something went wrong :(");
            }
        });
    }, viewModel);

    viewModel.Delete = function (item) {
        var self = viewModel;
        $.ajax({
            type: "DELETE",
            url: "api/Categories/" + item.Id,
            success: function () {
                self.items.remove(item);
            },
            error: function() {
                alert("Something went wrong :(");
            }
        });
    };

    ko.applyBindings(viewModel);
});