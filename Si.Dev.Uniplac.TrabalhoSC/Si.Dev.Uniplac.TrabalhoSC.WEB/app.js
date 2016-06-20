angular.module("myApp", ['ui.router'])

.controller("ClienteCtrl", function ($http) {
    var self = this;
    $http.get("/api/Cliente/").then(function (res) {
        self.clientes = res;
    });
})
.controller("CarroCtrl", function () {

})
.controller("ServicoCtrl", function () {

})