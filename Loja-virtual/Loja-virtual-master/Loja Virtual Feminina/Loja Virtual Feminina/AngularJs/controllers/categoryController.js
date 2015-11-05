app = angular.module("MyApp.Category", []);

app.controller('categoryController', function PostController($scope, $http) {

    $scope.loading = true;
    $scope.addMode = false;
    $scope.categories = [];

    $http.get('/api/Categories/').success(function (data) {
        $scope.categories = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.category.editMode = !this.category.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    $scope.save = function (category) {
        $scope.loading = true;
        var saveCategory = category;
        $http.put('/api/Categories/', saveCategory).success(function (data) {
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Categories! " + data;
            $scope.loading = false;
        });
    };

    $scope.add = function (newCategory) {
        $scope.loading = true;
        $http.post('/api/Categories/', newCategory).success(function (data) {
            $scope.addMode = false;
            $scope.categories.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error on Add Categories! " + data;
            $scope.loading = false;
        });
    };

    $scope.delete = function (category) {
        $scope.loading = true;
        var categoryId = category.categoryId;
        $http.delete('/api/Categories/' + categoryId).success(function (data) {
            $.each($scope.categories, function (i) {
                if ($scope.categories[i].categoryId === categoryId) {
                    $scope.categories.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
           }).error(function (data) {
               $scope.error = "An Error has occured while Saving Categories! " + data;
            $scope.loading = false;

        });
    };

})