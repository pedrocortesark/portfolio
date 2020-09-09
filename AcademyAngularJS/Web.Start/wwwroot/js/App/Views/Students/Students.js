class Students
{
    get Id()
    {
        return this._id;
    }

    set Id(value)
    {
        this._id = value;
    }

    get Name()
    {
        return this._name;
    }

    set Name(value)
    {
        this._name = value;
    }

    get LastName1()
    {
        return this._lastName1;
    }

    set LastName1(value)
    {
        this._lastName1 = value;
    }

    get LastName2()
    {
        return this._lastName2;
    }

    set LastName2(value)
    {
        this._lastName2 = value;
    }

    get Dni()
    {
        return this._dni;
    }

    set Dni(value)
    {
        this._dni = value;
    }

    get Chair()
    {
        return this._chair;
    }

    set Chair(value)
    {
        this._chair = value;
    }

    get Students()
    {
        return this._students;
    }

    set Students(value)
    {
        this._students = value;
    }

    get Message()
    {
        return this._message;
    }

    set Message(value)
    {
        this._message = value;
    }

    get SelectedRows()
    {
        var selectedRows = this.gridOptions.gridApi.selection.getSelectedRows();
        return selectedRows[0];
    }

    set SelectedRows(value)
    {
        this._selectedRows = value;
    }


    //A veces cuando realizo cambios en el this, o en el scope el js necesita actualizarse.
    //Para ello añado en el contructor el scope y lo guardo en una variable
    //Para hacer uso de él, llamo a su método apply cuando recibo el callback
    //Es un estilo de OnPropertyChanged
    constructor(studentsService, $scope)
    {
        this._students = [];
        this.StudentsService = studentsService;
        this.Scope = $scope;
        this.Id = "";

        this.gridOptions = {
            enableSorting: false,
            enableColumnMenus: false,
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            muntiSelect: false,
            data: this.Students,
            selectedRows: [],
            columnDefs:
                [
                    { field: 'dni', visible: true, width: 110  },
                    { field: 'name', visible: true, width:110 },
                    { field: 'lastName', visible: true, width: 110  },
                    { field: 'lastName2', visible: true, width: 110  },
                    { field: 'completeName', visible: false },
                    { field: 'status', visible: false },
                    { field: 'chair', visible: true, width: 50},
                    { field: 'subjectsString', visible: true },
                    { field: 'numSubjects', visible: true, width: 50 },
                    { field: 'id', visible: false },
                    { field: 'currentValidation', visible: false },
                ],
            onRegisterApi: function (gridApi)
            {
                this.gridApi = gridApi;
            }
        }
    }

    GetStudents()
    {
        this.StudentsService.GetAllAsync(
            (peep) =>
            {
                this.LoadStudents(peep);
            });
    }


    LoadStudents(students)
    {
        this.Students.length = 0;
        for (let i in students)
        {
            this.Students.push(students[i]);
        }
    }

    SaveStudent()
    {
        var newStudent = new Student();

        newStudent.Id = this._id;
        newStudent.Name = this._name;
        newStudent.LastName = this._lastName1;
        newStudent.LastName2 = this._lastName2;
        newStudent.Chair = this._chair;
        newStudent.Dni = this._dni;

        if (newStudent.Id == "")
        {
            this.StudentsService.SaveStudentAsync(newStudent,
                (peep) =>
                {
                    this.StudentResult(peep);
                });
        }

        else
        {
            this.StudentsService.UpdateStudentAsync(newStudent,
                (peep) =>
                {
                    this.StudentResult(peep);
                });
        }

    }

    DeleteStudent()
    {

        if (this.SelectedRows == undefined)
            this.Message = "Before deleting you must select a student!!"

        else
        {
            this.StudentsService.DeleteStudentAsync(this.SelectedRows.id,
                (peep) =>
                {
                    this.DeleteResult(peep);
                });

        }
        
    }

    EditStudent()
    {
        if (this.Students.length == 0)
            this.Message = "Before editing, you must GetStudents!!"
        else
        {
            this.Id = this.SelectedRows.id;
            this.Name = this.SelectedRows.name;
            this.LastName1 = this.SelectedRows.lastName;
            this.LastName2 = this.SelectedRows.lastName2;
            this.Dni = this.SelectedRows.dni;
            this.Chair = this.SelectedRows.chair;
            this.Message = "Change whatever you want and save again!!"
        }

    }

    StudentResult(saveResult)
    {
        if (saveResult.isSuccess == true)
        {
            this.Clear();
            this.Message = "Student has been saved correctly!!"

        }

        else
            this.Message = saveResult.allErrors;

        this.Refresh();
        this.GetStudents();
    }

    DeleteResult(deleteResult)
    {
        if (deleteResult.isSuccess == true)
        {
            this.Clear();
            this.Message = "Student has been deleted correctly!!"

        }

        else
            this.Message = saveResult.allErrors;

        this.Refresh();
        this.GetStudents();
    }

    Clear()
    {
        this.Id = "";
        this.Name = "";
        this.LastName1 = "";
        this.LastName2 = "";
        this.Chair = "";
        this.Dni = "";
        this.Message = "";
    }

    Refresh()
    {
        try
        {
            this.Scope.$apply();
        }
        catch (error)
        {

        }
    }

}

Students.$inject = ['StudentsService','$scope'];

WebAcademyApp
    .component('students', {
        templateUrl: 'js/App/Views/Students/Students.html',
        controller: ('Students', Students),
        controllerAs: 'vm'
    });


