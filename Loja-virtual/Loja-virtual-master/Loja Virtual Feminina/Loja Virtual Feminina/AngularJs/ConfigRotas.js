

app = angular.module("Myapp", ['MyApp.Main', 'MyApp.User', 'MyApp.Product', 'MyApp.Category', 'MyApp.Cart','MyApp.Sale', 'ngRoute']);

app.config(function ($routeProvider)
{
    $routeProvider
        .when('/produto', { templateUrl: '/Templates/Product.html', controller: 'ProductController' })
        .when('/usuario', { templateUrl: '/Templates/User.html', controller: 'userController' })
        .when('/categoria', { templateUrl: '/Templates/Category.html', controller: 'categoryController' })
        .when('/cart', { templateUrl: '/Templates/Cart.html', controller: 'cartController' })
        .when('/sale', { templateUrl: '/Templates/Sale.html', controller: 'saleController' })
        .otherwise({ redirectTo: '/' });
});

