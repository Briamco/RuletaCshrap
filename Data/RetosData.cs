using Ruleta.Utils;

namespace Ruleta.Data;

class RetosData
{
  public static string[]? retos;

  public static bool ValidarIndice(int i)
  {
    return ValidationHelper.ValidarIndice(i, retos, "retos");
  }
  public static void CargarRetos()
  {
    retos = ArchivoHelper.CargarRetos();
  }
  public static void GuardarRetos()
  {
    ArchivoHelper.GuardarRetos(retos);
  }
  public static string? CargarRetoPorIndice(int i)
  {
    if (retos == null)
    {
      StyleConsole.Error("No hay retos cargados");
      return null;
    }
    if (!ValidarIndice(i)) return null;

    return retos[i];
  }
  public static string[]? CrearReto(string Reto)
  {
    if (Reto == null || Reto.Trim() == "")
    {
      StyleConsole.Error("No se pudo crear el reto. Intente nuevamente.");
      return null;
    }

    if (retos == null)
    {
      retos = new string[] { Reto };
      return retos;
    }
    int n = retos.Length;

    string[] nuevoArreglo = new string[n + 1];

    for (int i = 0; i < n; i++)
    {
      nuevoArreglo[i] = retos[i];
    }

    nuevoArreglo[n] = Reto;

    retos = nuevoArreglo;
    StyleConsole.WriteLine("Reto agregado con éxito.", ConsoleColor.Green);

    return retos;
  }
  public static string[]? ActualizarReto(int i, string Reto)
  {
    if (retos == null)
    {
      StyleConsole.Error("No hay retos cargados.");
      return null;
    }

    if (!ValidarIndice(i)) return retos;

    if (Reto == null || Reto.Trim() == "")
    {
      Console.WriteLine("No se pudo actualizar el reto.");
      return retos;
    }

    retos[i] = Reto;
    StyleConsole.WriteLine("Reto actualizado con éxito.", ConsoleColor.Green);

    return retos;
  }
  public static string[]? EliminarReto(int i)
  {
    if (retos == null)
    {
      StyleConsole.Error("No hay retos cargados.");
      return null;
    }

    if (!ValidarIndice(i)) return retos;

    int n = retos.Length;

    string[] nuevoArrego = new string[n - 1];

    int j = 0;
    for (int k = 0; k < n; k++)
    {
      if (k == i) continue;

      nuevoArrego[j] = retos[k];
      j++;
    }

    retos = nuevoArrego;
    StyleConsole.WriteLine("Reto eliminado con éxito.", ConsoleColor.Green);

    return retos;
  }
}