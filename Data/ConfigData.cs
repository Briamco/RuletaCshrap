using System.Drawing;
using Ruleta.Utils;

namespace Ruleta.Data;

public static class ConfigData
{
  public static string[]? config;

  public static string[]? ModificarRoles(string Dev, string Fac)
  {
    if (Dev == null || Dev.Trim() == "" || Fac == null || Fac.Trim() == "")
    {
      StyleConsole.Error("Los roles no pueden estar vacíos. Intente nuevamente.");
      return null;
    }

    if (config == null)
    {
      config = new string[2];
    }

    config[0] = Dev;
    config[1] = Fac;

    StyleConsole.WriteLine("Roles modificados. Presione Enter para continuar.", ConsoleColor.Green);

    return config;
  }
  public static void CargarCongif()
  {
    config = ArchivoHelper.CargarConfig();
  }
  public static void GuardarConfig()
  {
    ArchivoHelper.GuardarConfig(config);
  }
}