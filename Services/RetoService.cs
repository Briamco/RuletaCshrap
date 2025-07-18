using Ruleta.Utils;

namespace Ruleta.Services;

class RetoService
{
  private static readonly Random random = new();
  public static string? AsignarReto(string[]? retos)
  {
    if (retos == null || retos.Length == 0)
    {
      StyleConsole.Error("No hay retos disponibles.");
      return null;
    }

    int index = random.Next(retos.Length);
    StyleConsole.WriteLine("Reto asignado:", ConsoleColor.Cyan);
    AnimationHelper.LoopAnimation(retos, retos[index], ConsoleColor.Yellow);
    Console.WriteLine();
    return retos[index];
  }
  public static string[]? AsignarPareja(string[] parejas)
  {
    if (parejas == null || parejas.Length == 0)
    {
      StyleConsole.Error("No hay parejas disponibles.");
      return null;
    }

    int index = random.Next(parejas.Length);
    string[] pareja = parejas[index].Split(" || ");

    StyleConsole.WriteLine("Pareja asignada:", ConsoleColor.Cyan);
    AnimationHelper.LoopAnimation(parejas, pareja[0], ConsoleColor.Green);
    Console.WriteLine();
    return [parejas[index], $"{index}"];
  }
}
