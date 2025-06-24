using Ruleta.Models;

namespace Ruleta.Data;

public static class EstudiantesData
{
  public static Estudiante[]? estudiantes;
  public static void CargarEstudiantes()
  {
    estudiantes = ArchivoHelper.CargarEstudiantes();
  }

  public static Estudiante? CargarEstudiantePorIndice(int i)
  {
    if (estudiantes == null)
    {
      Console.WriteLine("No hay estudiantes cargados.");
      return null;
    }

    if (i < 0 || i >= estudiantes.Length)
    {
      Console.WriteLine("Índice fuera de rango.");
      return null;
    }

    return estudiantes[i];
  }

  public static void GuardarEstudiantes()
  {
    if (estudiantes == null)
    {
      Console.WriteLine("Índice inválido. No se pudo guardar los estudiantes.");
      return;
    }

    if (estudiantes != null) ArchivoHelper.GuardarEstudiantes(estudiantes);
  }

  public static void CrearEstudiante(Estudiante estudiante)
  {
    if (estudiante == null)
    {
      Console.WriteLine("No se pudo crear el estudiante. Intente nuevamente.");
      return;
    }

    if (estudiantes == null)
    {
      estudiantes = new Estudiante[] { estudiante };
    }
    else
    {
      Estudiante[] nuevoArreglo = new Estudiante[estudiantes.Length + 1];
      for (int i = 0; i < estudiantes.Length; i++)
      {
        nuevoArreglo[i] = estudiantes[i];
      }
      nuevoArreglo[estudiantes.Length] = estudiante;
      estudiantes = nuevoArreglo;
    }
  }


  public static void ActualizarEstudiante(int i, Estudiante estudiante)
  {
    if (estudiantes == null || i < 0 || i >= estudiantes.Length)
    {
      Console.WriteLine("Índice inválido. No se pudo actualizar el estudiante.");
      return;
    }
    if (estudiante == null)
    {
      Console.WriteLine("No se pudo actualizar el estudiante. Intente nuevamente.");
      return;
    }

    estudiantes[i] = estudiante;
  }

  public static void EliminarEstudiante(int i)
  {
    if (estudiantes == null || i < 0 || i >= estudiantes.Length)
    {
      Console.WriteLine("Índice inválido. No se pudo eliminar el estudiante.");
      return;
    }

    Estudiante[] nuevoArreglo = new Estudiante[estudiantes.Length - 1];
    int j = 0;
    for (int k = 0; k < estudiantes.Length; k++)
    {
      if (k == i) continue;
      nuevoArreglo[j++] = estudiantes[k];
    }

    estudiantes = nuevoArreglo;
  }
}
