$(document).ready(function () {
    var viewModel = {
        items: ko.observableArray([])
    };

    viewModel.GetBooks = ko.computed(function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: "api/Books",
            success: function (data) {

                for (var i = 0; i < data.length; i++) {
                    self.items.push({ Name: data[i].Name, Id: data[i].Id, ISBN: data[i].ISBN, Author: data[i].Author, Categories: data[i].CategoriesList });
                }
                return data;
            },
            error: function (data) {
                debugger;
                alert("Something went wrong :(");
            }
        });
    }, viewModel);

    viewModel.Delete = function (item) {
        $.ajax({
            type: "DELETE",
            url: "api/Books/" + item.Id,
            success: function () {
                viewModel.items.remove(item);
            },
            error: function () {
                alert("Something went wrong :(");
            }
        });
    }
    ko.applyBindings(viewModel);
});