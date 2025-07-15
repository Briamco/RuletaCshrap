using System.Data;
using Ruleta.Utils;

namespace Ruleta.Data;

public static class ParejasData
{
  public static string[]? parejasActuales;
  public static string[][]? parejas;

  public static bool ValidarIndiceActuales(int i)
  {
    return ValidationHelper.ValidarIndice(i, parejasActuales, "parejas");
  }
  public static bool ValidarIndiceHistorial(int i)
  {
    return ValidationHelper.ValidarIndiceArrayDoble(i, parejas, "historial");
  }
  public static string[]? AgregarPareja(string pareja)
  {
    if (pareja == null)
    {
      StyleConsole.Error("No se pudo crear la pareja. Intente nuevamente.");
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
    if (parejasActuales == null)
    {
      StyleConsole.Error("No hay parejas cargadas");
      return new string[0];
    }

    if (!ValidarIndiceActuales(i)) return new string[0];

    parejasActuales[i] = nuevaPareja;
    return parejasActuales;
  }

  public static string[]? ActualizarPareja(int iHis, int iPar, string nuevaPareja)
  {
    if (parejas == null)
    {
      StyleConsole.Error("No hay parejas cargadas");
      return new string[0];
    }

    if (!ValidarIndiceHistorial(iHis)) return new string[0];

    parejas[iHis][iPar] = nuevaPareja;

    return parejas[iHis];
  }

  public static void GuardarParejasPasadas(int i)
  {
    if (parejas == null)
    {
      StyleConsole.Error("No hay parejas cargadas");
      return;
    }

    ArchivoHelper.GuardarParejasPasadas(parejas[i], i);
  }

  public static void CargarParejas()
  {
    parejas = ArchivoHelper.CargarHistorialesPorArchivo();
  }

  public static string[]? CargarParejaPorIndice(int i)
  {
    if (parejas == null)
    {
      StyleConsole.Error("No hay historial de parejas cargado.");
      return null;
    }

    if (!ValidarIndiceHistorial(i)) return null;

    return parejas[i];
  }

  public static void GuardarParejas()
  {
    if (parejasActuales == null)
    {
      StyleConsole.Error("No hay parejas para guardar.");
      return;
    }

    ArchivoHelper.GuardarParejas(parejasActuales);
  }
}