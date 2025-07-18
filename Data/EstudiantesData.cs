using Ruleta.Utils;

namespace Ruleta.Data;

public static class EstudiantesData
{
  public static string[]? estudiantes;
  public static bool[]? fueDev;
  public static bool[]? fueFac;


  public static void CargarEstudiantes()
  {
    estudiantes = ArchivoHelper.CargarEstudiantes();

    if (estudiantes != null)
    {
      fueDev = new bool[estudiantes.Length];
      fueFac = new bool[estudiantes.Length];
    }
  }
  public static bool ValidarIndice(int i)
  {
    return ValidationHelper.ValidarIndice(i, estudiantes, "estudiantes");
  }
  public static string? CargarEstudiantePorIndice(int i)
  {
    if (!ValidarIndice(i)) return null;

    return estudiantes?[i];
  }
  public static void GuardarEstudiantes()
  {
    if (estudiantes == null)
    {
      StyleConsole.Error("No hay estudiantes para guardar.");
      return;
    }

    ArchivoHelper.GuardarEstudiantes(estudiantes);
  }
  public static string[]? AgregarEstudiante(string estudiante)
  {
    if (estudiante == null || estudiante.Trim() == "")
    {
      StyleConsole.Error("El nombre del estudiante no puede estar vacío. Intente nuevamente.");
      return estudiantes;
    }

    if (estudiantes == null)
    {
      estudiantes = new string[] { estudiante };
      fueDev = new bool[] { false };
      fueFac = new bool[] { false };
      return estudiantes;
    }
    else
    {
      int n = estudiantes.Length;

      string[] nuevoArreglo = new string[n + 1];
      bool[] nuevoDev = new bool[n + 1];
      bool[] nuevoFac = new bool[n + 1];

      for (int i = 0; i < n; i++)
      {
        nuevoArreglo[i] = estudiantes[i];
        nuevoDev[i] = fueDev?[i] ?? false;
        nuevoFac[i] = fueFac?[i] ?? false;
      }

      nuevoArreglo[n] = estudiante;
      nuevoDev[n] = false;
      nuevoFac[n] = false;

      estudiantes = nuevoArreglo;
      fueDev = nuevoDev;
      fueFac = nuevoFac;
      StyleConsole.WriteLine("Estudiante agregado con éxito.", ConsoleColor.Green);

      return estudiantes;
    }
  }
  public static string[]? ActualizarEstudiante(int i, string estudiante)
  {
    if (estudiantes == null)
    {
      StyleConsole.Error("No hay estudiantes cargados.");
      return null;
    }
    if (!ValidarIndice(i)) return null;
    if (estudiante == null || estudiante.Trim() == "")
    {
      StyleConsole.Error("No se pudo actualizar el estudiante. Intente nuevamente.");
      return estudiantes;
    }

    estudiantes[i] = estudiante;
    StyleConsole.WriteLine("Estudiante actualizado con éxito.", ConsoleColor.Green);

    return estudiantes;
  }
  public static string[]? EliminarEstudiante(int i)
  {
    if (estudiantes == null || fueDev == null || fueFac == null)
    {
      StyleConsole.Error("No hay estudiantes cargados.");
      return null;
    }

    if (!ValidarIndice(i)) return null;

    int n = estudiantes.Length;
    string[] nuevoEstudiantes = new string[n - 1];
    bool[] nuevoDev = new bool[n - 1];
    bool[] nuevoFac = new bool[n - 1];

    int j = 0;
    for (int k = 0; k < n; k++)
    {
      if (k == i) continue;

      nuevoEstudiantes[j] = estudiantes[k];
      nuevoDev[j] = fueDev[k];
      nuevoFac[j] = fueFac[k];
      j++;
    }

    estudiantes = nuevoEstudiantes;
    fueDev = nuevoDev;
    fueFac = nuevoFac;
    StyleConsole.WriteLine("Estudiante eliminado con éxito.", ConsoleColor.Green);

    return estudiantes;
  }
}
