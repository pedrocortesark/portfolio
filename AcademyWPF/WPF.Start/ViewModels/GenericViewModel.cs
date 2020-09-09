using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WPF.Start.ViewModels
{
    public class GenericViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        //#region DataError

        //public string Error { get; private set; }

        //public string this[string columnName] => throw new NotImplementedException();

        //#endregion

        //Delegado para ejecutar acción de mostrar mensaje

        public static Action<string> ShowMessageAction { get; set; }


        public void ShowMessage(string msg)
        {
            if (ShowMessageAction != null)
                ShowMessageAction(msg);
        }




    }
}
