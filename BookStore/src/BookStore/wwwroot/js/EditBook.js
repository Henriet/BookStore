$(document).ready(function () {

    var viewModel = {
        Name: ko.observable(''),
        ISBN: ko.observable(''),
        Author: ko.observable(''),
        SelectedCategories: ko.observableArray([]),
        Id: ko.observable(''),
        AllCategories: ko.observableArray([])
    };

    var category = function (name, id) {
        this.Name = name;
        this.Id = id;
    };

    viewModel.UploadAllCategories = ko.computed(function () {
        var self = this;
        var id = $('#Id').val();
        $.ajax({
            type: "GET",
            url: window.location.protocol + "//" + window.location.host + "/api/Categories/",

            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    self.AllCategories.push(new category(data[i].Name, data[i].Id));
                }
                $.ajax({
                    type: "GET",
                    url: window.location.protocol + "//" + window.location.host + "/api/Books/" + id,

                    success: function (data) {
                        self.Name(data.Name);
                        self.ISBN(data.ISBN);
                        self.Id(data.Id);
                        self.Author(data.Author);

                        for (var i = 0; i < data.Categories.length; i++) {
                            self.SelectedCategories.push(data.Categories[i].Id);
                        }
                    },
                    error: function () {
                        alert("Something went wrong :(");
                    }
                });
            },
            error: function () {
                alert("Something went wrong :(");
            }
        });

    }, viewModel);

    viewModel.Update = function () {
        var self = this;
        var selectedCategories = viewModel.SelectedCategories();
        var categories = [];
        for (var i = 0; i < selectedCategories.length; i++) {
            categories.push(new category("", selectedCategories[i]));
        }
        var data = JSON.stringify({ Id: self.Id(), Name: self.Name(), ISBN: self.ISBN(), Author: self.Author(), Categories: categories, CategoriesList: '' });
       // var data = JSON.stringify({ Categories: [], Id: 1, Name: "The Story Of Our Lives", ISBN: "1", Author: "Mark Strand" });
        debugger;
        console.log(data);
        $.ajax({
            type: "PUT",
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
    };

    ko.applyBindings(viewModel);
});