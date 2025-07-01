using Screens.CrudsScreen;
using Screens.Juego;

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
      default:
        Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
        break;
    }
  }
  public static void Screen(int exitInput)
  {
    Console.Clear();
    Console.WriteLine("1.Ruleta");
    Console.WriteLine("2.Almacenamiento de datos");
    Console.WriteLine("5.Configuracion");
    Console.WriteLine($"{exitInput}.Salir");
  }
}