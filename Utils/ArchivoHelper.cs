using System.Text;

public static class ArchivoHelper
{
  private const string RutaEstudiantes = "Storage/Estudiantes.txt";
  private const string RutaParejas = "Storage/Historial";

  private const string RutaConfig = "Storage/Config.txt";
  public static void GuardarEstudiantes(string[] estudiantes)
  {
    using (StreamWriter write = new StreamWriter(RutaEstudiantes, false, Encoding.UTF8))
    {
      foreach (var est in estudiantes)
      {
        write.WriteLine(est);
      }
    }
  }


  public static string[] CargarEstudiantes()
  {
    if (!File.Exists(RutaEstudiantes))
    {
      return new string[0];
    }

    var lines = File.ReadAllLines(RutaEstudiantes);
    string[] estudiantes = new string[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
      string Nombre = lines[i];
      estudiantes[i] = Nombre;
    }

    return estudiantes;
  }

  public static void GuardarParejas(string[] parejas)
  {
    var archivos = Directory.GetFiles(RutaParejas, "historial_*.txt");

    // Obtener el número siguiente
    int numero = archivos.Length + 1;
    string archivoNombre = Path.Combine(RutaParejas, $"historial_{numero}.txt");

    using (StreamWriter write = new StreamWriter(archivoNombre, false, Encoding.UTF8))
    {
      foreach (var prj in parejas)
      {
        write.WriteLine(prj);
      }
    }

    Console.WriteLine($"Parejas guardadas en el archivo: {archivoNombre}");
  }

  public static string[][] CargarHistorialesPorArchivo()
  {
    if (!Directory.Exists(RutaParejas))
    {
      Console.WriteLine("No existe el directorio de Hitoriales.");
      return new string[0][];
    }

    string[] archivos = Directory.GetFiles(RutaParejas, "historial_*.txt");
    string[][] historial = new string[archivos.Length][];

    for (int i = 0; i < archivos.Length; i++)
    {
      string[] lineas = File.ReadAllLines(archivos[i], Encoding.UTF8);
      string[] parejasDeArchivo = new string[lineas.Length];

      for (int j = 0; j < lineas.Length; j++)
      {
        parejasDeArchivo[j] = lineas[j];
      }

      historial[i] = parejasDeArchivo;
    }

    return historial;
  }
  public static void GuardarConfig(string[]? config)
  {
    using (StreamWriter write = new StreamWriter(RutaConfig, false, Encoding.UTF8))
    {
      if (config == null || config.Length == 0)
      {
        write.WriteLine("Desarrollador en Vivo");
        write.WriteLine("Facilitador");
        return;
      }
      foreach (var c in config)
      {
        write.WriteLine(c);
      }
    }
  }

  public static string[]? CargarCongif()
  {
    if (!File.Exists(RutaConfig))
    {
      return new string[] { "Desarrollador en Vivo", "Facilitador" };
    }

    string[] lineas = File.ReadAllLines(RutaConfig);

    return lineas;
  }
}
