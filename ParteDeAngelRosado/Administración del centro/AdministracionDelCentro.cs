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
