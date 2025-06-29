using System.Data;

namespace Ruleta.Data;

public static class ParejasData
{
  public static string[]? parejasActuales;
  public static string[][]? parejas;

  public static string[]? AgregarPareja(string pareja)
  {
    if (pareja == null)
    {
      Console.WriteLine("No se pudo crear la pareja. Intente nuevamente.");
      return parejasActuales;
    }

    if (parejasActuales == null)
    {
      parejasActuales = new string[] { pareja };
      return parejasActuales;
    }
    else
    {
      string[] nuevoArreglo = new string[parejasActuales.Length + 1];
      for (int i = 0; i < parejasActuales.Length; i++)
      {
        nuevoArreglo[i] = parejasActuales[i];
      }
      nuevoArreglo[parejasActuales.Length] = pareja;
      parejasActuales = nuevoArreglo;
      return parejasActuales;
    }
  }
  public static string[]? ActualizarParejaActual(int i, string nuevaPareja)
  {
    if (parejasActuales == null || i < 0 || i >= parejasActuales.Length)
    {
      Console.WriteLine("Índice fuera de rango o no hay parejas cargadas.");
      return null;
    }

    parejasActuales[i] = nuevaPareja;
    return parejasActuales;
  }

  public static void CargarParejas()
  {
    parejas = ArchivoHelper.CargarHistorialesPorArchivo();
  }

  public static string[]? CargarParejaPorIndice(int i)
  {
    if (parejas == null || i < 0 || i >= parejas.Length)
    {
      Console.WriteLine("Índice fuera de rango o no hay parejas cargadas.");
      return null;
    }

    return parejas[i];
  }

  public static void GuardarParejas()
  {
    if (parejasActuales == null)
    {
      Console.WriteLine("No hay parejas para guardar.");
      return;
    }

    ArchivoHelper.GuardarParejas(parejasActuales);
  }
}