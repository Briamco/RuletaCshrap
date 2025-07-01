using Ruleta.Screen;
using Ruleta.Services;
using Ruleta.Utils;

namespace Screens.CrudsScreen;

class CrudsScreen
{
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        EstudiantesMenu.MainScreen();
        break;
      case 2:
        HistorialScreen.MainScreen();
        break;
      case 3:
        RetosScreen.MainScreen();
        break;
      default:
        Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine("1.Estudiantes");
      Console.WriteLine("2.Historial");
      Console.WriteLine("3.Retos");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}