using Examen_ordinario.enumerador;
using Examen_ordinario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ordinario.Clases
{
    internal class Capibara : IMascota //Clase de Capibara con la interfas IMascota
    {
        string IMascota.Nombre
        {
            get;
            set;
        }
        int IMascota.Edad
        {
            get;
            set;
        }
        string IMascota.dueño
        {
            get;
            set;
        }

        ComportamientoEnum IMascota.Comportamiento { get; }

        void IMascota.CambiarDueño(int id_dueño)
        {

        }

        void IMascota.HacerRuido()
        {
            Console.WriteLine("cui cui");
        }
    }
}
