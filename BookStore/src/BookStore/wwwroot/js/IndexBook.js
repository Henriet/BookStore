$(document).ready(function () {

    var GetBooks = function () {
        var self = this;
        self.items = ko.observableArray([]);
        self.Delete = function (item) {
            new DeleteItem(item, self);
        }
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
    }

    ko.applyBindings(new GetBooks());

    var DeleteItem = function(item, that) {
        $.ajax({
            type: "DELETE",
            url: "api/Books/" + item.Id,
            success: function () {
                that.items.remove(item);
            },
            error: function () {
                alert("Something went wrong :(");
            }
        });
    }
});