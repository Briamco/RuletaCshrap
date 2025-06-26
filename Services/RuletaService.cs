using Ruleta.Data;

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
      Console.WriteLine("No hay suficientes estudiantes para iniciar la ruleta.");
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
        Console.WriteLine("Todos los estudiantes ya han sido seleccionados. Fin de la ruleta.");
        Console.WriteLine("Presiona Enter para salir.");
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
        Console.WriteLine("No hay combinaciones posibles restantes.");
        break;
      }

      fueDev[i1] = true;
      fueFac[i2] = true;

      Console.Clear();
      Console.WriteLine($"{estudiantes[i1]}: {RolDev}");
      Console.WriteLine($"{estudiantes[i2]}: {RolFac}");

      ParejasData.AgregarPareja($"{estudiantes[i1]}, {RolDev} - {estudiantes[i2]}, {RolFac}");

      Console.WriteLine("\nPresiona Enter para continuar o escribe 'salir' para terminar.");
      string? input = Console.ReadLine();
      if (input?.ToLower() == "salir") break;
    }
  }
}
