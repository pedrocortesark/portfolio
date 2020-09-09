class ExampleVar
{
    get IsLogon()
    {
        return this._isLogon;
    }
    set IsLogon(value)
    {
        this._isLogon = value;
    }

    constructor()
    {
        this._isLogon = false;
    }

}