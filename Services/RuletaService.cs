using Ruleta.Data;
using Ruleta.Utils;

namespace Ruleta.Services;

public static class RuletaService
{
  private static string RolDev = ConfigData.config?[0] ?? "Desarrollador en Vivo";
  private static string RolFac = ConfigData.config?[1] ?? "Facilitador";

  public static void IniciarRuleta()
  {
    string[]? estudiantes = EstudiantesData.estudiantes;

    if (estudiantes == null || estudiantes.Length < 2)
    {
      StyleConsole.Title("RULETA", 30);
      StyleConsole.Error("No hay suficientes estudiantes para iniciar la ruleta.");
      return;
    }

    int total = estudiantes.Length;
    bool[] fueDev = EstudiantesData.fueDev ?? new bool[total];
    bool[] fueFac = EstudiantesData.fueFac ?? new bool[total];

    Random random = new Random();

    while (true)
    {
      bool terminado = true;
      for (int i = 0; i < total; i++)
      {
        if (!fueDev[i] || !fueFac[i])
        {
          terminado = false;
          break;
        }
      }

      if (terminado)
      {
        StyleConsole.Title("RULETA FINALIZADA", 35);
        StyleConsole.WriteLine("Todos los estudiantes ya han sido seleccionados. Fin de la ruleta.", ConsoleColor.Yellow);
        StyleConsole.WriteLine("Presiona Enter para salir.", ConsoleColor.Cyan);
        Console.ReadLine();
        break;
      }

      int i1, i2;
      int intentos = 0;

      do
      {
        i1 = random.Next(total);
        intentos++;
        if (intentos > 1000) break;
      } while (fueDev[i1]);

      intentos = 0;
      do
      {
        i2 = random.Next(total);
        intentos++;
        if (intentos > 1000) break;
      } while (i2 == i1 || fueFac[i2]);

      if (fueDev[i1] || fueFac[i2])
      {
        StyleConsole.Title("SIN COMBINACIONES", 35);
        StyleConsole.Error("No hay combinaciones posibles restantes.");
        break;
      }

      fueDev[i1] = true;
      fueFac[i2] = true;


      Console.Clear();
      StyleConsole.Title("PAREJA ASIGNADA", 35);

      AnimationHelper.LoopAnimation(estudiantes, estudiantes[i1], ConsoleColor.Green);
      StyleConsole.WriteLine($": {RolDev}", ConsoleColor.Green);
      InputHelper.Continuar("Presiona cualquier tecla para seguir con la seleccion...");

      AnimationHelper.LoopAnimation(estudiantes, estudiantes[i2], ConsoleColor.Cyan);
      StyleConsole.WriteLine($": {RolFac}", ConsoleColor.Cyan);

      ParejasData.AgregarPareja($"{estudiantes[i1]}, {RolDev} - {estudiantes[i2]}, {RolFac}");

      StyleConsole.WriteLine("\nPresiona Enter para continuar o escribe 'salir' para terminar.", ConsoleColor.Yellow);
      string? input = Console.ReadLine();
      if (input?.ToLower() == "salir") break;
    }
  }
}
