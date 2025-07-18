using Ruleta.Utils;

namespace Ruleta.Services;

class ContadorService
{
  public static string Contador()
  {
    string time;
    int min = 0, sec = 0, ms = 0;

    Sound.ClockSound();

    while (true)
    {
      time = $"{min:D2}:{sec:D2}:{ms:D2}";
      Console.Clear();
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.WriteLine($"Tiempo: {time}", ConsoleColor.Green);
      StyleConsole.WriteLine("Presiona cualquier tecla para detener...", ConsoleColor.Yellow);
      Thread.Sleep(10);
      ms++;

      if (ms >= 99)
      {
        ms = 0;
        sec++;
      }

      if (sec >= 59)
      {
        sec = 0;
        min++;
      }

      if (Console.KeyAvailable)
      {
        Sound.StopSound();
        Sound.StopClockSound();
        break;
      }
    }
    return time;
  }
  public static string? IniciarContador(string pareja)
  {
    if (pareja == null)
    {
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.WriteLine("No se pudo iniciar el contador. Intente nuevamente.", ConsoleColor.Red);
      return null;
    }

    string tiempo = Contador();
    Console.Clear();
    StyleConsole.Title("CONTADOR FINALIZADO", 35);
    StyleConsole.WriteLine("Contador detenido!", ConsoleColor.Cyan);
    StyleConsole.WriteLine($"Pareja: {pareja}", ConsoleColor.Green);
    StyleConsole.WriteLine($"Tiempo: {tiempo}", ConsoleColor.Yellow);
    Console.ReadLine();
    return tiempo;
  }
}