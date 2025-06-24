using Ruleta.Services;

public static class MainMenu
{
  public static void Navigator(int op)
  {
    switch (op)
    {
      case 1:
        RuletaService.IniciarRuleta();
        break;
      case 2:
        EstudiantesMenu.MainScreen();
        break;
      case 3:
        HistorialScreen.MainScreen();
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
    Console.WriteLine("2.Estudiantes");
    Console.WriteLine("3.Historial");
    Console.WriteLine($"{exitInput}.Salir");
  }
}