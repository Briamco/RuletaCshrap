namespace Ruleta.Data;

public static class ConfigData
{
  public static string[]? config;

  public static string[]? ModificarRoles(string Dev, string Fac)
  {
    if (Dev == null || Fac == null)
    {
      Console.WriteLine("No se pudo modificar los roles. Intente nuevamente.");
      return null;
    }

    if (config == null)
    {
      config = new string[2];
    }

    config[0] = Dev;
    config[1] = Fac;

    Console.WriteLine("Roles modificados. Presione Enter para continuar.");

    return config;
  }
  public static void CargarCongif()
  {
    config = ArchivoHelper.CargarCongif();
  }
  public static void GuardarConfig()
  {
    ArchivoHelper.GuardarConfig(config);
  }
}