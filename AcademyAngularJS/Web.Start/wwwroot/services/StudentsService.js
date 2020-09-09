class StudentsService
{
    constructor($http)
    {
        this.Http = $http;
        this.Students = [];
    }

    get Students()
    {
        return this._students;
    }

    set Students(value)
    {
        this._students = value;
    }

    GetAllAsync(callback)
    {
        if (this.Students.length > 0)
            callback(this.Students);

        this.Http.get("/api/students")
            .then(
                (response) =>
                {
                    this.Students = response.data;
                    callback(this.Students);
                },
                function errorCallback(response)
                {
                    console.log("POST-ing of data failed");
                });
    }

    SaveStudentAsync(newStudent, callback)
    {
        this.Http.post("/api/students", newStudent)
            .then(
                (response) =>
                {
                    let data = response.data;
                    callback(data);

                },
                function errorCallback(response)
                {
                    console.log("POST-ing of data failed");
                });
    }

    UpdateStudentAsync(newStudent, callback)
    {
        this.Http.put("/api/students", newStudent)
            .then(
                (response) =>
                {
                    let data = response.data;
                    callback(data);

                },
                function errorCallback(response)
                {
                    console.log("POST-ing of data failed");
                });
    }

    DeleteStudentAsync(studentId, callback)
    {
        this.Http.delete("/api/students/" + studentId)
            .then(
                (response) =>
                {
                    let data = response.data;
                    callback(data);

                },
                function errorCallback(response)
                {
                    console.log("POST-ing of data failed");
                });
    }


}

StudentsService.$inject = ['$http'];
WebAcademyApp.service('StudentsService', StudentsService);