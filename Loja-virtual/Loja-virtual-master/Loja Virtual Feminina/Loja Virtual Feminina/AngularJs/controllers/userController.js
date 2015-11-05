

app = angular.module("MyApp.User", []);

app.controller('userController', function PostController($scope, $http) {
    
    $scope.loading = true;
    $scope.addMode = false;
    $scope.users = [];

    $http.get('/api/Users/').success(function (data) {
        $scope.users = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.user.editMode = !this.user.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    $scope.save = function () {
        $scope.loading = true;
        var saveUser = $scope.user;
        $http.put('/api/Users/', saveUser).success(function (data) {
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Users! " + data;
            $scope.loading = false;
        });
    };

    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Users/', $scope.newUser).success(function (data) {
            $scope.addMode = false;
            $scope.users.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error on Add User! " + data;
            $scope.loading = false;
        });
    };

    $scope.delete = function () {
        $scope.loading = true;
        var userId = $scope.user.userId;
        $http.delete('/api/Users/' + userId).success(function (data) {
            $.each($scope.users, function (i) {
                if ($scope.users[i].userId === userId) {
                    $scope.users.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving users! " + data;
            $scope.loading = false;

        });
    };

})
