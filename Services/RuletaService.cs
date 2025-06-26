using Ruleta.Data;

namespace Ruleta.Services;

public static class RuletaService
{
  //Ruleta exploto
  private static string RolDev = "Desarrollador en Vivo";
  private static string RolFac = "Facilitador";

  public static void IniciarRuleta()
  {

    string[]? estudiantes = EstudiantesData.estudiantes;

    if (estudiantes == null || estudiantes.Length < 2)
    {
      Console.WriteLine("No hay suficientes estudiantes para iniciar la ruleta.");
      return;
    }

    string[]? estudiantesSeleccionados = new string[estudiantes.Length - 2];
    string[]? roles = new string[estudiantesSeleccionados.Length];
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

      estudiantesSeleccionados.Append(estudiantes[i1]);
      estudiantesSeleccionados.Append(estudiantes[i2]);
      roles.Append(RolDev);
      roles.Append(RolFac);

      Console.WriteLine($"🧑‍💻 {estudiantes[i1]}: {RolDev}");
      Console.WriteLine($"🧑‍💻 {estudiantes[i2]}: {RolFac}");

      ParejasData.AgregarPareja($"{estudiantes[i1]}, {RolDev} - {estudiantes[i2]}, {RolFac}");

      Console.WriteLine("\nPresiona Enter para continuar o escribe 'salir' para terminar.");
      string? input = Console.ReadLine();
      if (input?.ToLower() == "salir") break;
    }
  }
}
