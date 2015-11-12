

app = angular.module("Myapp", ['MyApp.Main', 'MyApp.User', 'MyApp.Product', 'MyApp.Category', 'MyApp.Cart', 'MyApp.Sale', 'MyApp.ShowCase', 'MyApp.Admin', 'ngRoute']);

app.config(function ($routeProvider)
{
    $routeProvider
         .when('/admin', { templateUrl: '/Templates/Admin.html', controller: 'adminController' })
        .when('/showcase', { templateUrl: '/Templates/showCase.html', controller: 'showcaseController' })
        .when('/produto', { templateUrl: '/Templates/Product.html', controller: 'ProductController' })
        .when('/usuario', { templateUrl: '/Templates/User.html', controller: 'userController' })
        .when('/categoria', { templateUrl: '/Templates/Category.html', controller: 'categoryController' })
        .when('/cart', { templateUrl: '/Templates/Cart.html', controller: 'cartController' })
        .when('/sale', { templateUrl: '/Templates/Sale.html', controller: 'saleController' })
        .otherwise({ redirectTo: '/' });
});

