using Ruleta.Data;

namespace Ruleta.Services;

class RetoService
{
  private static readonly Random random = new();
  public static string? AsignarReto(string[]? retos)
  {
    if (retos == null || retos.Length == 0)
    {
      Console.WriteLine("No hay retos disponibles.");
      return null;
    }

    int index = random.Next(retos.Length);
    return retos[index];
  }
  public static string[]? AsignarPareja(string[] parejas)
  {
    if (parejas == null || parejas.Length == 0)
    {
      Console.WriteLine("No hay parejas disponibles.");
      return null;
    }

    int index = random.Next(parejas.Length);
    Console.WriteLine($"Pareja asignada: {index}");
    return [parejas[index], index.ToString()];
  }
}
