var WebAcademyApp = angular.module('WebAcademyApp',
    [   'ngRoute',
        'ui.bootstrap',
        'ui.grid',
        'ui.grid.selection'
    ]);

WebAcademyApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider)
{   
    $routeProvider
        .when('/home', {
            templateUrl: 'default.html',
        })
        .when('/students', {
            templateUrl: 'js/App/Views/Students/Students.html',
            controller: ('Students', Students),
            controllerAs: 'vm'
        })
        .when('/subjects', {
            templateUrl: 'js/App/Views/Subjects/Subjects.html',
            controller: ('Subjects', Subjects),
            controllerAs: 'vm'
        });

    $locationProvider.html5Mode(true);

}]);

var GlobalVar = new ExampleVar();