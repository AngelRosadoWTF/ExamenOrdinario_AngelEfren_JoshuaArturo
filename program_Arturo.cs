using Examen_ordinario.Clases;
using Examen_ordinario.enumerador;
using Examen_ordinario.Interfaces;
namespace Examen_ordinario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int selector = 6;
            
            AdministracionMascotas administrador_mascotas = new AdministracionMascotas();
            Console.WriteLine("Seleccione una opccion del Administrador de mascotas");
           switch (selector) 
           {
                case 1:
                    administrador_mascotas.MascotasRegistradas();
                case 2:
                    administrador_mascotas.RegistrarMascota();
                case 3:
                    administrador_mascotas.BuscarMascotaId();
                case 4:
                    administrador_mascotas.BuscarMascotaNombre();
                case 5:
                    administrador_mascotas.ExaminarMascota();
                case 6:
                break;
            }
        }

        Persona persona = new Persona();


    }

    class SimulacionInterracciones 
    {
       public void Interaccion(int id) 
       {

       }
    }

    class AdministracionMascotas
    {

        public void MascotasRegistradas()
        {

        }

        public void RegistrarMascota()
        {

        }

        public void BuscarMascotaId()
        {

        }
        public void BuscarMascotaNombre()
        {

        }
        public void ExaminarMascota()
        {

        }
    }
}
