angular.module("myApp", ['ui.router'])

.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('home', {
            url: '/home',
            templateUrl: 'templates/home.html',
            controller: 'ClienteCtrl',
            controllerAs: 'ctrl'
        })
        .state('cliente', {
            url: '/cliente',
            templateUrl: 'templates/cliente.html'
        })
        .state('carro', {
            url: '/carro',
            templateUrl: 'templates/carro.html'
        })
        .state('servico', {
            url: '/servico',
            templateUrl: 'templates/servico.html',
            controller: 'ServicoCtrl',
            controllerAs: 'ctrl'
        })
})
.controller("ClienteCtrl", function ($http) {
    var self = this;
    self.carros = {};
    self.clientes = {};
    self.toggleEdit = false;
    self.toggleAdd = false;
    self.clone = {};

    $http.get("http://localhost:51870/api/Cliente/").then(function (res) {
        self.clientes = res.data;
    });
    self.delete = function (obj) {
        $http.delete("http://localhost:51870/api/Cliente/" + obj.Id).then(function (res) {
            self.clientes = res;
        });
    };
    self.edit = function (obj) {
        $http.put("http://localhost:51870/api/Cliente/" + obj.Id, obj).then(function (res) {
            self.clientes = res;
        });
    };
    self.add = function (obj) {
        $http.post("http://localhost:51870/api/Cliente/", obj).then(function (res) {
            self.clientes = res;
        });
    };
    self.cloneItem = function (obj) {
        self.clone = angular.copy(obj);
    };
    self.cancel = function (index) {
        self.clientes[index] = self.clone;
    }
})
.controller("CarroCtrl", function () {
})
.controller("ServicoCtrl", function ($http) {
    var self = this;
    self.servicos = {};
    self.clientes = {};
    self.toggleEdit = false;
    self.toggleAdd = false;
    self.clone = {};

    $http.get("http://localhost:51870/api/Servico").then(function (res) {
        self.servicos = res.data;
    });
    $http.get("http://localhost:51870/api/Cliente/").then(function (res) {
        self.clientes = res.data;
    });
    self.delete = function (obj) {
        $http.delete("http://localhost:51870/api/Servico/" + obj.Id).then(function (res) {
            self.servicos = res;
        });
    };
    self.edit = function (obj) {
        $http.put("http://localhost:51870/api/Servico/" + obj.Id, obj).then(function (res) {
            console.log("success");
        });
    };
    self.add = function (obj) {
        $http.post("http://localhost:51870/api/Servico/", obj).then(function (res) {
            self.servicos = res;
        });
    };
    self.cloneItem = function (obj) {
        self.clone = angular.copy(obj);
    };
    self.cancel = function (index) {
        self.servicos[index] = self.clone;
    }
})