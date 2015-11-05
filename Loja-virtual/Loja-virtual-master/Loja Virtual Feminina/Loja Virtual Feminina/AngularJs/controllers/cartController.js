app = angular.module("MyApp.Cart", []);

app.controller('cartController', function PostController($scope, $http) {

    $scope.loading = true;
    $scope.addMode = false;
    $scope.carts = [];
    $scope.products = [];

    $http.get('/api/Carts/').success(function (data) {
        $scope.carts = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $http.get('/api/Products/').success(function (data) {
        $scope.products = data;
        console.log($scope.products);
        $scope.loading = false;
    })
   .error(function () {
       $scope.error = "An Error has occured while loading posts!";
       $scope.loading = false;
   });

    $scope.toggleEdit = function () {
        this.cart.editMode = !this.cart.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    $scope.save = function (cart) {
        $scope.loading = true;
        var saveCart = cart;
        $http.put('/api/Carts/', saveCart).success(function (data) {
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Carts! " + data;
            $scope.loading = false;
        });
    };

    $scope.add = function (newCart) {
        $scope.loading = true;
        $http.post('/api/Carts/', newCart).success(function (data) {
            $scope.addMode = false;
            $scope.carts.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error on Add Carts! " + data;
            $scope.loading = false;
        });
    };

    $scope.delete = function (cart) {
        $scope.loading = true;
        var cartId = cart.cartId;
        $http.delete('/api/Carts/' + cartId).success(function (data) {
            $.each($scope.carts, function (i) {
                if ($scope.carts[i].cartId === cartId) {
                    $scope.carts.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
           }).error(function (data) {
               $scope.error = "An Error has occured while Saving Carts! " + data;
            $scope.loading = false;
        });
    };

})