using System.Text;
using Ruleta.Models;

public static class ArchivoHelper
{
  private const string Ruta = "Storage/Estudiantes.txt";

  public static void GuardarEstudiantes(Estudiante[] estudiantes)
  {
    using (StreamWriter write = new StreamWriter(Ruta, false, Encoding.UTF8))
    {
      foreach (var est in estudiantes)
      {
        write.WriteLine(est.Nombre);
      }
    }
  }

  public static Estudiante[] CargarEstudiantes()
  {
    if (!File.Exists(Ruta))
    {
      return new Estudiante[0];
    }

    var lines = File.ReadAllLines(Ruta);
    Estudiante[] estudiantes = new Estudiante[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
      string Nombre = lines[i];
      estudiantes[i] = new Estudiante
      {
        Nombre = Nombre
      };
    }

    return estudiantes;
  }
}