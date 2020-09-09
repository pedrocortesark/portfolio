class Subjects
{

}

//Sintaxis para relacionar html y js a través de los controladores de angular
Subjects.$inject = ['$http'];

WebAcademyApp
    .component('students', {
        templateUrl: 'js/App/Views/Subjects/Subjects.html',
        controller: ('Subjects', Subjects),
        controllerAs: 'vm'
    });
