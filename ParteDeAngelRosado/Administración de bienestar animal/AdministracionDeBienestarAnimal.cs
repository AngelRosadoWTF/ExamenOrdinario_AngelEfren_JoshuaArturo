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