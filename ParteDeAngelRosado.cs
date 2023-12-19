using System;
using System.Collections.Generic;
using System.Linq;
using static Program;

class Program
{
    private static object personas;

    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Centro de Mascotas");
            Console.WriteLine("1 - Administración del centro");
            Console.WriteLine("2 - Administración de adopciones");
            Console.WriteLine("3 - Administración de bienestar animal");
            Console.WriteLine("4 - Simulación de interacciones");
            Console.WriteLine("5 - Finalizar programa");
            Console.Write("Seleccione una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AdministracionDelCentro();
                    break;
                case 2:
                    AdministracionDeAdopciones();
                    break;
                case 3:
                    AdministracionDeBienestarAnimal();
                    break;
                case 4:
                    Interaccion();
                    break;
                case 5:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
    static void AdministracionDelCentro()
    {
        bool regresar = false;
        while (!regresar)
        {
            Console.WriteLine("Administración del Centro");
            Console.WriteLine("1 - Administración de personas");
            Console.WriteLine("2 - Administración de mascotas");
            Console.WriteLine("3 - Regresar al menú anterior");
            Console.Write("Seleccione una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AdministracionDePersonas();
                    break;
                case 2:
                    AdministracionDeMascotas();
                    break;
                case 3:
                    regresar = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Mascota> Mascotas { get; set; }

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Mascotas = new List<Mascota>();
        }

        public void AgregarMascota(Mascota mascota)
        {
            Mascotas.Add(mascota);
        }
    }

    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Temperamento { get; set; }
        public int Edad { get; set; }
        public Persona Dueño { get; set; }

        public Mascota(int id, string nombre, string especie, string temperamento, int edad)
        {
            Id = id;
            Nombre = nombre;
            Especie = especie;
            Temperamento = temperamento;
            Edad = edad;
        }

    }

    static void AdministracionDePersonas()
    {
        List<Persona> personas = new List<Persona>();
        int contadorPersonas = 0;

        static void MostrarPersonas(List<Persona> personas)
        {
            foreach (var persona in personas)
            {
                Console.WriteLine($"ID: {persona.Id}, Nombre: {persona.Nombre}");
            }
        }

        static void RegistrarPersona(List<Persona> personas, int contadorPersonas)
        {
            Console.Write("Ingrese el nombre de la nueva persona: ");
            string nombre = Console.ReadLine();
            personas.Add(new Persona(++contadorPersonas, nombre));
            Console.WriteLine("Persona registrada con éxito.");
        }

        static void BuscarPersonasPorNombre(List<Persona> personas, string nombre)
        {
            Console.Write("Ingrese el nombre a buscar: ");
            string nombre = Console.ReadLine().ToLower(System.Globalization.CultureInfo.CurrentCulture);
            var personasEncontradas = personas.Where(p => p.Nombre.ToLower().Contains(nombre)).ToList();

            if (personasEncontradas.Count == 0)
            {
                Console.WriteLine("No se encontraron personas con ese nombre.");
                return;
            }

            foreach (var persona in personasEncontradas)
            {
                Console.WriteLine($"ID: {persona.Id}, Nombre: {persona.Nombre}");
            }
        }

        static void ExaminarPersona(List<Persona> personas, int id)
        {
            Console.Write("Ingrese el ID de la persona que desea examinar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Entrada no válida.");
                return;
            }

            var persona = personas.FirstOrDefault(p => p.Id == id);

            if (persona == null)
            {
                Console.Write("Persona no encontrada. ¿Desea buscar por nombre? (s/n): ");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta == "s")
                {
                    BuscarYExaminarPorNombre();
                }
                return;
            }

            MostrarInformacionPersona(persona);
        }

        static void MostrarInformacionPersona(Persona persona)
        {
            Console.WriteLine($"ID: {persona.Id}, Nombre: {persona.Nombre}");
            if (persona.Mascotas.Count == 0)
            {
                Console.WriteLine("Esta persona no posee mascotas.");
            }
            else
            {
                Console.WriteLine("Mascotas:");
                foreach (var mascota in persona.Mascotas)
                {
                    Console.WriteLine($"ID Mascota: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}");
                }
            }
        }

        static void BuscarYExaminarPorNombre(Persona persona)
        {
            Console.Write("Ingrese el nombre a buscar: ");
            string nombre = Console.ReadLine().ToLower();
            var personasEncontradas = personas.Where(p => p.Nombre.ToLower().Contains(nombre)).ToList();

            if (personasEncontradas.Count == 0)
            {
                Console.WriteLine("No se encontraron personas con ese nombre.");
                return;
            }
            else if (personasEncontradas.Count == 1)
            {
                MostrarInformacionPersona(personasEncontradas.First());
            }
            else
            {
                foreach (var persona in personasEncontradas)
                {
                    Console.WriteLine($"ID: {persona.Id}, Nombre: {persona.Nombre}");
                }

                Console.Write("Ingrese el ID de la persona a examinar: ");
                if (!int.TryParse(Console.ReadLine(), out int idSeleccionado))
                {
                    Console.WriteLine("Entrada no válida.");
                    return;
                }

                var personaSeleccionada = personasEncontradas.FirstOrDefault(p => p.Id == idSeleccionado);
                if (personaSeleccionada != null)
                {
                    MostrarInformacionPersona(personaSeleccionada);
                }
                else
                {
                    Console.WriteLine("ID no válido.");
                }
            }
        }
    }

    static void AdministracionDeMascotas()
    {
        static void AdministracionDeMascotas()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("1 - Mostrar todas las mascotas registradas");
                Console.WriteLine("2 - Registrar mascota nueva");
                Console.WriteLine("3 - Buscar mascotas por especie");
                Console.WriteLine("4 - Buscar mascotas por nombre");
                Console.WriteLine("5 - Examinar mascota");
                Console.WriteLine("6 - Volver al menú anterior");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MostrarTodasLasMascotas();
                        break;
                    case 2:
                        RegistrarMascotaNueva();
                        break;
                    case 3:
                        BuscarMascotasPorEspecie();
                        break;
                    case 4:
                        BuscarMascotasPorNombre();
                        break;
                    case 5:
                        ExaminarMascota();
                        break;
                    case 6:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void MostrarTodasLasMascotas()
        {

        }

        static void RegistrarMascotaNueva()
        {

        }

        static void BuscarMascotasPorEspecie()
        {

        }

        static void BuscarMascotasPorNombre()
        {

        }

        static void ExaminarMascota()
        {

        }
    }

    static void AdministracionDeAdopciones()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("1 - Ver mascotas disponibles para adoptar");
            Console.WriteLine("2 - Adoptar mascota");
            Console.WriteLine("3 - Regresar al menú anterior");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    VerMascotasDisponibles();
                    break;
                case 2:
                    AdoptarMascota();
                    break;
                case 3:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void VerMascotasDisponibles()
    {
        var mascotasDisponibles = personas.SelectMany(p => p.Mascotas.Where(m => m.DisponibleParaAdopcion)).ToList();
        foreach (var mascota in mascotasDisponibles)
        {
            Console.WriteLine($"ID: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}");
        }
    }

    static void AdoptarMascota()
    {
        Console.Write("Ingrese el ID de la mascota que desea adoptar: ");
        int idMascota = Convert.ToInt32(Console.ReadLine());

        var mascota = personas.SelectMany(p => p.Mascotas).FirstOrDefault(m => m.Id == idMascota && m.DisponibleParaAdopcion);

        if (mascota == null)
        {
            Console.Write("Mascota no encontrada. ¿Desea buscar por especie? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                BuscarMascotaPorEspecie();
            }
            return;
        }

        RealizarAdopcion(mascota);
    }

    static void BuscarMascotaPorEspecie()
    {
        Console.Write("Ingrese la especie de la mascota que desea adoptar: ");
        string especie = Console.ReadLine();

        var mascotasPorEspecie = personas.SelectMany(p => p.Mascotas)
                                          .Where(m => m.Especie.Equals(especie, StringComparison.OrdinalIgnoreCase) && m.DisponibleParaAdopcion)
                                          .ToList();

        if (mascotasPorEspecie.Count == 0)
        {
            Console.WriteLine("No hay mascotas disponibles de esa especie.");
            return;
        }

        foreach (var mascota in mascotasPorEspecie)
        {
            Console.WriteLine($"ID: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}");
        }

        Console.Write("¿Desea adoptar alguna de estas mascotas? (s/n): ");
        if (Console.ReadLine().ToLower() != "s")
        {
            return;
        }

        Console.Write("Ingrese el ID de la mascota que desea adoptar: ");
        int idMascota = Convert.ToInt32(Console.ReadLine());
        var mascotaSeleccionada = mascotasPorEspecie.FirstOrDefault(m => m.Id == idMascota);

        if (mascotaSeleccionada != null)
        {
            RealizarAdopcion(mascotaSeleccionada);
        }
        else
        {
            Console.WriteLine("ID no válido.");
        }
    }

    static void RealizarAdopcion(Mascota mascota)
    {

    }

    static void AdministracionDeBienestarAnimal()
    {
        static void AdministracionDeBienestarAnimal()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("1 - Servicio de Spa");
                Console.WriteLine("2 - Corte de pelo");
                Console.WriteLine("3 - Volver al menú anterior");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ServicioDeSpa();
                        break;
                    case 2:
                        CorteDePelo();
                        break;
                    case 3:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void ServicioDeSpa()
        {
            var persona = ObtenerPersona();
            if (persona == null) return;

            MostrarMascotasYSeleccionarServicio(persona, "Spa");
        }

        static void CorteDePelo()
        {
            var persona = ObtenerPersona();
            if (persona == null) return;

            MostrarMascotasYSeleccionarServicio(persona, "Corte de pelo");
        }

        static void MostrarMascotasYSeleccionarServicio(Persona persona, string servicio)
        {

        }
    }

    private static Persona ObtenerPersona()
    {

    }


}
