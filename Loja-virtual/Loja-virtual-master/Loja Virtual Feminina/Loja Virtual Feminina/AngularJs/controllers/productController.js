app = angular.module("MyApp.Product", []);

app.controller('ProductController', function PostController($scope, $http) {

    $scope.loading = true;
    $scope.addMode = false;
    $scope.products = [];
    $scope.categories = [];

    $http.get('/api/Products/').success(function (data) {
        $scope.products = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $http.get('/api/Categories/').success(function (data) {
        $scope.categories = data;
        $scope.loading = false;
    })
   .error(function () {
       $scope.error = "An Error has occured while loading posts!";
       $scope.loading = false;
   });

    $scope.toggleEdit = function () {
        $scope.product.editMode = !$scope.product.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    $scope.save = function (product) {
        $scope.loading = true;
        var saveProd = product;
        $http.put('/api/Products/',saveProd).success(function (data) {
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Products! " + data;
            $scope.loading = false;
        });
    };

    $scope.add = function (newProduct) {
        $scope.loading = true;
        $http.post('/api/Products/',newProduct).success(function (data) {
            $scope.addMode = false;
            $scope.products.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error on Add Products! " + data;
            $scope.loading = false;
        });
    };

    $scope.delete = function (product) {
        $scope.loading = true;
        var productId = product.productId;
        $http.delete('/api/Products/' + productId).success(function (data) {
            $.each($scope.products, function (i) {
                if ($scope.products[i].productId === productId) {
                    $scope.products.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
           }).error(function (data) {
            $scope.error = "An Error has occured while Saving products! " + data;
            $scope.loading = false;

        });
    };

})