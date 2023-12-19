using Examen_ordinario.enumerador;
using Examen_ordinario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ordinario.Clases
{
    public class Gato : IMascota //Clase de gato con la interfas IMascota
    {
        ComportamientoEnum IMascota.Comportamiento { get; }
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

        public void CambiarDueño(int id_dueño)
        {
           
        }

        public void HacerRuido()
        {
            Console.WriteLine("miau miau");
        }
    }
}
