class Index
{
    get MiVariable()
    {
        return GlobalVar.IsLogon;
    }

    constructor($http)
    {
        this.Http = $http;        
    }
}

//Sintaxis para relacionar html y js a través de los controladores de angular
Index.$inject = ['$http'];

WebAcademyApp
    .component('index', {
        templateUrl: 'js/App/Views/Index/index.html',
        controller: ('Index', Index),
        controllerAs: 'vm'
    });
