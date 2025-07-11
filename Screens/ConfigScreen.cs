using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;

public static class ConfigScreen
{
  private static string[]? config = ConfigData.config;

  public static void ModificarRoles(string[] lastConfig)
  {
    StyleConsole.Title("MODIFICAR ROLES");
    StyleConsole.WriteLine("Ingrese los nuevos roles o presione Enter para mantener los actuales.", ConsoleColor.Cyan);
    string? Dev = InputHelper.LeerTexto($"{lastConfig[0]}: ", ConsoleColor.Green);
    string? Fac = InputHelper.LeerTexto($"{lastConfig[1]}: ", ConsoleColor.Blue);

    if (Dev == null || Fac == null)
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
      StyleConsole.Error("Configuracion no encontrada o incompleta.");
      return;
    }

    Console.Clear();
    switch (op)
    {
      case 1:
        ModificarRoles(config);
        break;
      default:
        StyleConsole.Error("Ninguna opcion es valida, intente nuevamente");
        break;
    }
    InputHelper.Continuar();
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title("CONFIGURACIÓN");
      StyleConsole.WriteLine("1. Modificar Roles", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}