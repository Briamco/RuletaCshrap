using Ruleta.Models;

namespace Ruleta.Data;

public static class ConfigData
{
  public static Config config = new Config { };

  public static Config? ModificarRoles(string Dev, string Fac)
  {
    if (Dev == null || Fac == null)
    {
      Console.WriteLine("No se pudo modificar los roles. Intente nuevamente.");
      return null;
    }

    config.DevRol = Dev;
    config.FacRol = Fac;

    Console.WriteLine("Roles modificados. Presione Enter para continuar.");

    return config;
  }
  public static void CargarCongif()
  {
    ArchivoHelper.CargarCongif();
  }
  public static void GuardarConfig()
  {
    ArchivoHelper.GuardarConfig(config);
  }
}