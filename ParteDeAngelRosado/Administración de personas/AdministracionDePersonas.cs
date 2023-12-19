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
