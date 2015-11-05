app = angular.module("MyApp.Main", []);



app.controller('MainController', function ($scope) {

    $scope.submitForm = function () {
        if ($scope.userForm.$valid) {
            alert('Cadastro Realizado com sucesso!');
        }
    };
});