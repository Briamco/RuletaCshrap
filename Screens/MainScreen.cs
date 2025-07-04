using Ruleta.Services;

public static class MainMenu
{
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        RuletaService.IniciarRuleta();
        break;
      case 2:
        ContadorMenu.MainScreen();
        break;
      case 3:
        EstudiantesMenu.MainScreen();
        break;
      case 4:
        HistorialScreen.MainScreen();
        break;
      case 5:
        RetosScreen.MainScreen();
        break;
      case 6:
        ConfigScreen.MainScreen();
        break;
      default:
        Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }

  public static void Screen(int exitInput)
  {
    Console.Clear();
    Console.WriteLine("1.Iniciar Ruleta");
    Console.WriteLine("2.Contador");
    Console.WriteLine("3.Estudiantes");
    Console.WriteLine("4.Historial");
    Console.WriteLine("5.Retos");
    Console.WriteLine("6.Configuracion");
    Console.WriteLine($"{exitInput}.Salir");
  }
}