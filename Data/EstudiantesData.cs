namespace Ruleta.Data;

public static class EstudiantesData
{
  public static string[]? estudiantes;
  public static bool ValidarIndice(int i)
  {
    if (estudiantes == null || estudiantes.Length == 0)
    {
      Console.WriteLine("No hay estudiantes cargados.");
      return false;
    }

    if (i < 0 || i >= estudiantes.Length)
    {
      Console.WriteLine("Índice fuera de rango.");
      return false;
    }

    return true;
  }
  public static void CargarEstudiantes()
  {
    estudiantes = ArchivoHelper.CargarEstudiantes();
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
      Console.WriteLine("No hay estudiantes para guardar.");
      return;
    }

    ArchivoHelper.GuardarEstudiantes(estudiantes);
  }

  public static string[]? CrearEstudiante(string estudiante)
  {
    if (estudiante == null)
    {
      Console.WriteLine("No se pudo crear el estudiante. Intente nuevamente.");
      return estudiantes;
    }

    if (estudiantes == null)
    {
      estudiantes = new string[] { estudiante };
      return estudiantes;
    }
    else
    {
      string[] nuevoArreglo = new string[estudiantes.Length + 1];
      for (int i = 0; i < estudiantes.Length; i++)
      {
        nuevoArreglo[i] = estudiantes[i];
      }
      nuevoArreglo[estudiantes.Length] = estudiante;
      estudiantes = nuevoArreglo;
      return estudiantes;
    }
  }

  public static string[]? ActualizarEstudiante(int i, string estudiante)
  {
    if (estudiantes == null)
    {
      Console.WriteLine("No hay estudiantes cargados.");
      return null;
    }
    if (!ValidarIndice(i)) return null;
    if (estudiante == null)
    {
      Console.WriteLine("No se pudo actualizar el estudiante. Intente nuevamente.");
      return estudiantes;
    }

    estudiantes[i] = estudiante;
    return estudiantes;
  }

  public static string[]? EliminarEstudiante(int i)
  {
    if (estudiantes == null)
    {
      Console.WriteLine("No hay estudiantes cargados.");
      return null;
    }
    if (!ValidarIndice(i)) return null;

    string[] nuevoArreglo = new string[estudiantes.Length - 1];
    int j = 0;
    for (int k = 0; k < estudiantes.Length; k++)
    {
      if (k == i) continue;
      nuevoArreglo[j++] = estudiantes[k];
    }
    estudiantes = nuevoArreglo;
    return estudiantes;
  }
}
