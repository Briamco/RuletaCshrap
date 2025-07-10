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
        StyleConsole.Error("Ninguna opción es válida, intente nuevamente");
        break;
    }
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title("GESTIÓN DE DATOS", 40);
      StyleConsole.WriteLine("1. Estudiantes", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Historial", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Retos", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}