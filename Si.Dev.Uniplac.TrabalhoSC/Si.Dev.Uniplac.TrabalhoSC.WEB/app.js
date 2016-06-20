angular.module("myApp", ['ui.router'])

.controller("ClienteController", function ($http) {
    var self = this;
    $http.get('http://localhost:51870/api/Cliente/').then(function (response) {
        self.clientes = response;
    });
})
.controller("ServicoController", function () {

})
.controller("CarroController", function () {

})
.service("ClienteService", function () {

})
.service("ServicoService", function () {

})
.service("CarroService", function () {

})
