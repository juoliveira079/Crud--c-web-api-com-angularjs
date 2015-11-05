app = angular.module("MyApp.Sale", []);

app.controller('saleController', function PostController($scope, $http) {

    $scope.loading = true;
    $scope.addMode = false;
    $scope.sales = [];
    $scope.carts = [];
    $scope.users = [];
    $scope.products = [];

    $http.get('/api/Sales/').success(function (data) {
        $scope.sales = data;
        console.log($scope.sales);
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $http.get('/api/Carts/').success(function (data) {
        $scope.carts = data;
        $scope.loading = false;
    })
 .error(function () {
     $scope.error = "An Error has occured while loading posts!";
     $scope.loading = false;
 });

    $http.get('/api/Users/').success(function (data) {
        $scope.users = data;
        $scope.loading = false;
    })
 .error(function () {
     $scope.error = "An Error has occured while loading posts!";
     $scope.loading = false;
 });

    $http.get('/api/Products/').success(function (data) {
        $scope.products = data;
        $scope.loading = false;
    })
 .error(function () {
     $scope.error = "An Error has occured while loading posts!";
     $scope.loading = false;
 });

    $scope.toggleEdit = function () {
        this.sale.editMode = !this.sale.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    $scope.save = function (sale) {
        $scope.loading = true;
        var saveSale = sale;
        $http.put('/api/Sales/', saveSale).success(function (data) {
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Sales! " + data;
            $scope.loading = false;
        });
    };

    $scope.add = function (newSale) {
        $scope.loading = true;
        $http.post('/api/Sales/', newSale).success(function (data) {
            $scope.addMode = false;
            $scope.sales.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error on Add Sales! " + data;
            $scope.loading = false;
        });
    };

    $scope.delete = function (sale) {
        $scope.loading = true;
        var saleId = sale.saleId;
        $http.delete('/api/Sales/' + saleId).success(function (data) {
            $.each($scope.sales, function (i) {
                if ($scope.sales[i].saleId === saleId) {
                    $scope.sales.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
           }).error(function (data) {
               $scope.error = "An Error has occured while Saving Sales! " + data;
            $scope.loading = false;
        });
    };

})