class Login
{
    get Email()
    {
        return this._email;
    }

    set Email(value)
    {
        this._email = value;
    }

    get Password()
    {
        return this._password;
    }

    set Password(value)
    {
        this._password = value;
    }

    constructor($http)
    {
        this.Http = $http;
    }

    Login()
    {
        var data = new LoginDto();

        data.Email = this.Email;
        data.Password = this.Password;

        this.Http.post("/api/login", data)
            .then((response) =>
            {
                if (response.data === true)
                    GlobalVar.IsLogon = true;
            },
            function errorCallback(response)
            {
                console.log("POST-ing of data failed");
            }
        );
    }
}

Login.$inject = ['$http'];

WebAcademyApp
    .component('login', {
        templateUrl: 'js/App/Views/Login/Login.html',
        controller: ('Login', Login),
        controllerAs: 'vm'
    });