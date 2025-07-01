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
        Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine("1.Iniciar Ruleta");
      Console.WriteLine("2.Contador");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}