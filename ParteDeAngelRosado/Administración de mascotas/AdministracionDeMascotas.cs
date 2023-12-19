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
    foreach (var persona in personas)
    {
        foreach (var mascota in persona.Mascotas)
        {
            Console.WriteLine($"ID: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}");
        }
    }
}


static void RegistrarMascotaNueva()
{
    Console.Write("Ingrese el nombre de la mascota: ");
    string nombre = Console.ReadLine();

    Console.Write("Ingrese la especie de la mascota: ");
    string especie = Console.ReadLine();

    Console.Write("Ingrese el temperamento de la mascota: ");
    string temperamento = Console.ReadLine();

    Console.Write("Ingrese la edad de la mascota: ");
    int edad = int.Parse(Console.ReadLine());

    Mascota nuevaMascota = new Mascota(personas.SelectMany(p => p.Mascotas).Count() + 1, nombre, especie, temperamento, edad);

    Console.Write("¿Desea asignarle un dueño a la mascota? (s/n): ");
    if (Console.ReadLine().ToLower() == "s")
    {
        AsignarDueñoAMascota(nuevaMascota);
    }
    else
    {
        // La mascota no tiene dueño
        nuevaMascota.Dueño = null;
    }

    // Añadir la mascota a la colección global o a una lista de mascotas sin dueño
}

static void AsignarDueñoAMascota(Mascota mascota)
{
    // Implementar la lógica para asignar un dueño a la mascota
}


static void BuscarMascotasPorEspecie()
{
    Console.Write("Ingrese la especie de la mascota: ");
    string especie = Console.ReadLine();

    var mascotasEncontradas = personas.SelectMany(p => p.Mascotas)
                                      .Where(m => m.Especie.Equals(especie, StringComparison.OrdinalIgnoreCase))
                                      .ToList();

    foreach (var mascota in mascotasEncontradas)
    {
        Console.WriteLine($"ID: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}");
    }
}


static void BuscarMascotasPorNombre()
{
    Console.Write("Ingrese el nombre de la mascota: ");
    string nombre = Console.ReadLine();

    var mascotasEncontradas = personas.SelectMany(p => p.Mascotas)
                                      .Where(m => m.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                                      .ToList();

    foreach (var mascota in mascotasEncontradas)
    {
        Console.WriteLine($"ID: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}");
    }
}


static void ExaminarMascota()
{
    Console.Write("Ingrese el ID de la mascota: ");
    int id = int.Parse(Console.ReadLine());

    var mascota = personas.SelectMany(p => p.Mascotas).FirstOrDefault(m => m.Id == id);

    if (mascota == null)
    {
        Console.Write("Mascota no encontrada. ¿Desea buscar por nombre? (s/n): ");
        if (Console.ReadLine().ToLower() == "s")
        {
            BuscarMascotasPorNombre();
        }
        return;
    }

    Console.WriteLine($"ID: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}, Temperamento: {mascota.Temperamento}, Edad: {mascota.Edad}, Dueño: {mascota.Dueño?.Nombre ?? "Sin dueño"}");
}