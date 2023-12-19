using Examen_ordinario.enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ordinario.Interfaces
{
    internal interface IMascota // Interfas de mascota
    {
        public ComportamientoEnum Comportamiento { get; }
        public static int id { get; set; }
        string Nombre { get; set; }
        int Edad { get; set; }

        string dueño { get; set; }

        void HacerRuido();
        void CambiarDueño(int id_dueño);
    }
}
