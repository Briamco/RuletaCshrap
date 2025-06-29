using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;

public static class ConfigScreen
{
  private static string[]? config = ConfigData.config;

  public static void ModificarRoles(string[] lastConfig)
  {
    Console.Write($"{lastConfig[0]}: ");
    string? Dev = Console.ReadLine();
    Console.Write($"{lastConfig[1]}: ");
    string? Fac = Console.ReadLine();

    if (string.IsNullOrEmpty(Dev) || string.IsNullOrEmpty(Fac))
    {
      Dev = "Desarrollador en Vivo";
      Fac = "Facilitador";
    }
    config = ConfigData.ModificarRoles(Dev, Fac) ?? config;
  }
  public static void Navigator(int op)
  {
    if (config == null)
    {
      Console.WriteLine("Error: Configuracion no encontrada o incompleta.");
      return;
    }

    Console.Clear();
    switch (op)
    {
      case 1:
        ModificarRoles(config);
        break;
      default:
        Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
        break;
    }
    Console.WriteLine("Presiona cualquier tecla para continuar...");
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