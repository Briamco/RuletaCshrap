using System.Text;
using Ruleta.Utils;

public static class ArchivoHelper
{
  private const string RutaEstudiantes = "Storage/Estudiantes.txt";
  private const string RutaParejas = "Storage/Historial";
  private const string RutaConfig = "Storage/Config.txt";
  private const string RutaRetos = "Storage/Retos.txt";
  private static string[] DefaultConfig = { "Desarrollador en Vivo", "Facilitador" };

  private static void GuardarArchivo(string ruta, string[] lineas)
  {
    using (StreamWriter write = new StreamWriter(ruta, false, Encoding.UTF8))
    {
      foreach (var linea in lineas)
      {
        write.WriteLine(linea);
      }
    }
  }

  private static string[] CargarArchivo(string ruta)
  {
    return File.Exists(ruta) ? File.ReadAllLines(ruta, Encoding.UTF8) : new string[0];
  }

  public static void GuardarEstudiantes(string[]? estudiantes) =>
    GuardarArchivo(RutaEstudiantes, estudiantes ?? new string[0]);

  public static string[] CargarEstudiantes() =>
    CargarArchivo(RutaEstudiantes);

  public static void GuardarParejas(string[] parejas)
  {
    Directory.CreateDirectory(RutaParejas);
    var archivos = Directory.GetFiles(RutaParejas, "historial_*.txt");
    int numero = archivos.Length;
    string archivoNombre = Path.Combine(RutaParejas, $"historial_{numero}.txt");
    GuardarArchivo(archivoNombre, parejas);
    StyleConsole.WriteLine($"Parejas guardadas en el archivo: {archivoNombre}", ConsoleColor.Cyan);
  }

  public static void GuardarParejasPasadas(string[] parejas, int i) =>
    GuardarArchivo($"{RutaParejas}/historial_{i}.txt", parejas);

  public static string[][] CargarHistorialesPorArchivo()
  {
    if (!Directory.Exists(RutaParejas))
    {
      StyleConsole.Error("No existe el directorio de Historiales.");
      return new string[0][];
    }

    string[] archivos = Directory.GetFiles(RutaParejas, "historial_*.txt");
    return archivos.Select(archivo => File.ReadAllLines(archivo, Encoding.UTF8)).ToArray();
  }

  public static void GuardarConfig(string[]? config) =>
    GuardarArchivo(RutaConfig, config is { Length: >= 2 } ? config : DefaultConfig);

  public static string[] CargarConfig()
  {
    var lineas = CargarArchivo(RutaConfig);
    return lineas.Length < 2 ? DefaultConfig : lineas;
  }

  public static void GuardarRetos(string[]? retos) =>
    GuardarArchivo(RutaRetos, retos ?? new string[0]);

  public static string[] CargarRetos() =>
    CargarArchivo(RutaRetos);
}
