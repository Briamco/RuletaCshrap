using System.Runtime.CompilerServices;

namespace Ruleta.Utils;

class AnimationHelper
{
  public static void LoadingAnimation(double duracion)
  {
    int counter = 0;
    DateTime endTIme = DateTime.Now.AddSeconds(duracion);

    StyleConsole.Write("Cargando");
    while (DateTime.Now < endTIme)
    {
      StyleConsole.Write(".");
      counter++;
      Thread.Sleep(100);
    }
  }
  public static void SpinnerAnimation(double duracion)
  {
    char[] spinner = { '|', '/', '-', '\\' };
    int counter = 0;
    DateTime endTIme = DateTime.Now.AddSeconds(duracion);

    while (DateTime.Now < endTIme)
    {
      StyleConsole.Write($"\r{spinner[counter % spinner.Length]}");
      counter++;
      Thread.Sleep(100);
    }
  }
  public static void LoopAnimation(string[] arr, string selected, ConsoleColor endColor = ConsoleColor.Yellow, bool sound = true, double duracion = 9)
  {
    ConsoleColor[] colores = { ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Magenta };
    int counter = 0;
    DateTime endTime = DateTime.Now.AddSeconds(duracion);

    int maxLength = arr.Max(s => s.Length);
    int baseDelay = 50;
    int delay = baseDelay;

    if (sound) Sound.RuletaSound();

    while (DateTime.Now < endTime)
    {
      double tiempoRestante = (endTime - DateTime.Now).TotalSeconds;

      if (tiempoRestante < duracion * 0.4) delay = baseDelay + 30;
      if (tiempoRestante < duracion * 0.2) delay = baseDelay + 70;

      string nombre = arr[counter % arr.Length].PadRight(maxLength);
      StyleConsole.Write($"\r{nombre}", colores[counter % colores.Length]);

      counter++;
      Thread.Sleep(delay);
    }

    string resultadoFinal = selected.PadRight(maxLength);
    StyleConsole.Write($"\r{resultadoFinal}", endColor);
    Thread.Sleep(1000 * 2);
  }
}