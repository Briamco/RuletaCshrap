using Ruleta.Screen;
using Ruleta.Services;
using Ruleta.Utils;

namespace Screens.Juego;

class JuegoScreen
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
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title("JUEGO");
      StyleConsole.WriteLine("1. Iniciar Ruleta", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Contador", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}