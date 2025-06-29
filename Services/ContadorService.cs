using System.Threading.Tasks;
using Ruleta.Data;

namespace Ruleta.Services;

class ContadorService
{
  public static string Contador()
  {
    string time;
    int min = 0, sec = 0, ms = 0;

    while (true)
    {
      time = $"{min:D2}:{sec:D2}:{ms:D2}";
      Console.Clear();
      Console.WriteLine(time);
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
        break;
      }
    }
    return time;
  }
  public static string? IniciarContador(string pareja)
  {
    if (pareja == null)
    {
      Console.WriteLine("No se pudo iniciar el contador. Intente nuevamente.");
      return null;
    }

    string tiempo = Contador();
    Console.Clear();
    Console.WriteLine("Contador iniciado!");
    Console.WriteLine($"Pareja: {pareja}, Tiempo: {tiempo}");
    return tiempo;
  }
}