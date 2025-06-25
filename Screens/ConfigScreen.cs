using System.Security.Cryptography.X509Certificates;
using Ruleta.Data;
using Ruleta.Models;
using Ruleta.Screen;
using Ruleta.Utils;

public static class ConfigScreen
{
  private static Config config = ConfigData.config;
  public static void ModificarRoles()
  {
    Console.Write($"{config.DevRol}: ");
    string? Dev = Console.ReadLine() ?? "";
    Console.Write($"{config.FacRol}: ");
    string? Fac = Console.ReadLine() ?? "";

    config = ConfigData.ModificarRoles(Dev, Fac) ?? config;
  }
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        ModificarRoles();
        break;
      default:
        Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
        break;
    }
    Console.ReadLine();
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine("1.Modificar Roles");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}