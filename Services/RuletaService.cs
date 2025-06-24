using Ruleta.Data;
using Ruleta.Models;

namespace Ruleta.Services;

public class RuletaService
{
  public static void IniciarRuleta()
  {
    Estudiante[] estudiantes = EstudiantesData.estudiantes ?? new Estudiante[0];
    Random random = new Random();

    while (true)
    {
      Console.Clear();
      int i1 = random.Next(estudiantes.Length);
      int i2;

      do
      {
        i2 = random.Next(estudiantes.Length);
      } while (i2 == i1);

      estudiantes[i1].Rol = "Desarrollador en Vivo";
      estudiantes[i2].Rol = "Facilitador";

      Console.WriteLine($"{estudiantes[i1].Nombre}: {estudiantes[i1].Rol}");
      Console.WriteLine($"{estudiantes[i2].Nombre}: {estudiantes[i2].Rol}");

      Console.WriteLine("\nPresiona Enter para continuar o escribe 'salir' para terminar.");
      string input = Console.ReadLine()!;
      if (input?.ToLower() == "salir") break;
    }
  }
}
