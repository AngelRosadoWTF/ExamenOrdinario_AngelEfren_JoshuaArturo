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