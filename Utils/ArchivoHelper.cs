using System.Text;
using Ruleta.Models;

public static class ArchivoHelper
{
  private const string RutaEstudiantes = "Storage/Estudiantes.txt";
  private const string RutaParejas = "Storage/Historial";

  public static void GuardarEstudiantes(Estudiante[] estudiantes)
  {
    using (StreamWriter write = new StreamWriter(RutaEstudiantes, false, Encoding.UTF8))
    {
      foreach (var est in estudiantes)
      {
        write.WriteLine(est.Nombre);
      }
    }
  }

  public static Estudiante[] CargarEstudiantes()
  {
    if (!File.Exists(RutaEstudiantes))
    {
      return new Estudiante[0];
    }

    var lines = File.ReadAllLines(RutaEstudiantes);
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

  public static void GuardarParejas(Pareja[] parejas)
  {
    var archivos = Directory.GetFiles(RutaParejas, "historial_*.txt");

    // Obtener el número siguiente
    int numero = archivos.Length + 1;
    string archivoNombre = Path.Combine(RutaParejas, $"historial_{numero}.txt");

    using (StreamWriter write = new StreamWriter(archivoNombre, false, Encoding.UTF8))
    {
      foreach (var prj in parejas)
      {
        write.WriteLine($"{prj.Nombre1},{prj.Rol1},{prj.Nombre2},{prj.Rol2}");
      }
    }

    Console.WriteLine($"Parejas guardadas en el archivo: {archivoNombre}");
  }

  public static Pareja[][] CargarHistorialesPorArchivo()
  {
    if (!Directory.Exists(RutaParejas))
    {
      Console.WriteLine("No existe el directorio de Hitoriales.");
      return new Pareja[0][];
    }

    string[] archivos = Directory.GetFiles(RutaParejas, "historial_*.txt");
    Pareja[][] historial = new Pareja[archivos.Length][];

    for (int i = 0; i < archivos.Length; i++)
    {
      string[] lineas = File.ReadAllLines(archivos[i], Encoding.UTF8);
      Pareja[] parejasDeArchivo = new Pareja[lineas.Length];

      for (int j = 0; j < lineas.Length; j++)
      {
        string[] datos = lineas[j].Split(',');

        if (datos.Length == 4)
        {
          parejasDeArchivo[j] = new Pareja
          {
            Nombre1 = datos[0],
            Rol1 = datos[1],
            Nombre2 = datos[2],
            Rol2 = datos[3]
          };
        }
        else
        {
          parejasDeArchivo[j] = new Pareja
          {
            Nombre1 = "Error",
            Rol1 = "-",
            Nombre2 = "-",
            Rol2 = "-"
          };
        }
      }

      historial[i] = parejasDeArchivo;
    }

    return historial;
  }
}