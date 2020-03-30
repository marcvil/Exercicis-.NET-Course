using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace A4_WPF
{
    //
    // Resumen:
    //     Define un comando.
    [TypeConverter("System.Windows.Input.CommandConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
    [TypeForwardedFrom("PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")]
    [ValueSerializer("System.Windows.Input.CommandValueSerializer, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
    public interface ICommand
    {
        //
        // Resumen:
        //     Se produce cuando hay cambios que influyen en si el comando debería ejecutarse
        //     o no.
        event EventHandler CanExecuteChanged;

        //
        // Resumen:
        //     Define el método que determina si el comando puede ejecutarse en su estado actual.
        //
        // Parámetros:
        //   parameter:
        //     Datos que usa el comando. Si el comando no exige pasar los datos, se puede establecer
        //     este objeto en null.
        //
        // Devuelve:
        //     true si se puede ejecutar este comando; de lo contrario, false.
        bool CanExecute(object parameter);
        //
        // Resumen:
        //     Define el método al que se llamará cuando se invoque el comando.
        //
        // Parámetros:
        //   parameter:
        //     Datos que usa el comando. Si el comando no exige pasar los datos, se puede establecer
        //     este objeto en null.
        void Execute(object parameter);
    }
}
