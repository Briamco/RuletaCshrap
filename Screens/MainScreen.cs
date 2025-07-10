using Screens.CrudsScreen;
using Screens.Juego;
using Ruleta.Utils;

public static class MainMenu
{
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        JuegoScreen.MainScreen();
        break;
      case 2:
        CrudsScreen.MainScreen();
        break;
      case 3:
        ConfigScreen.MainScreen();
        break;
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void Screen(int exitInput)
  {
    Console.Clear();
    StyleConsole.Title("MENÚ PRINCIPAL");
    StyleConsole.WriteLine("1. Ruleta", ConsoleColor.Green);
    StyleConsole.WriteLine("2. Almacenamiento de datos", ConsoleColor.Green);
    StyleConsole.WriteLine("3. Configuración", ConsoleColor.Green);
    StyleConsole.WriteLine($"{exitInput}. Salir", ConsoleColor.Red);
  }
}