using Ruleta.Data;
using Ruleta.Models;

namespace Ruleta.Services;

public static class RuletaService
{
  //Ruleta exploto
  private static string RolDev = ConfigData.config.DevRol;
  private static string RolFac = ConfigData.config.FacRol;

  public static void IniciarRuleta()
  {
    Estudiante[] estudiantes = EstudiantesData.estudiantes ?? new Estudiante[0];
    Random random = new Random();

    while (true)
    {
      Console.Clear();

      var candidatosDev = estudiantes.Where(e => !(e.Rol ?? new string[0]).Contains(RolDev)).ToList();
      var candidatosFac = estudiantes.Where(e => !(e.Rol ?? new string[0]).Contains(RolFac)).ToList();


      if (candidatosDev.Count == 0 || candidatosFac.Count == 0)
      {
        Console.WriteLine("Ya todos los estudiantes han recibido ambos roles. No se puede continuar.");
        Console.WriteLine("Presiona Enter para salir.");
        Console.ReadLine();
        return;
      }

      Estudiante estudianteDev, estudianteFac;
      do
      {
        estudianteDev = candidatosDev[random.Next(candidatosDev.Count)];
        estudianteFac = candidatosFac[random.Next(candidatosFac.Count)];
      } while (estudianteDev == estudianteFac);

      estudianteDev.Rol = AgregarRol(estudianteDev.Rol ?? new string[0], RolDev);
      estudianteFac.Rol = AgregarRol(estudianteFac.Rol ?? new string[0], RolFac);

      Console.WriteLine($"{estudianteDev.Nombre}: {RolDev}");
      Console.WriteLine($"{estudianteFac.Nombre}: {RolFac}");

      Pareja pareja = new Pareja
      {
        Nombre1 = estudianteDev.Nombre,
        Rol1 = RolDev,
        Nombre2 = estudianteFac.Nombre,
        Rol2 = RolFac
      };

      ParejasData.AgregarPareja(pareja);

      Console.WriteLine("\nPresiona Enter para continuar o escribe 'salir' para terminar.");
      string input = Console.ReadLine()!;
      if (input.Trim().ToLower() == "salir") break;
    }
  }

  private static string[] AgregarRol(string[] rolesActuales, string nuevoRol)
  {
    if (rolesActuales.Contains(nuevoRol)) return rolesActuales;

    string[] nuevoArreglo = new string[rolesActuales.Length + 1];
    for (int i = 0; i < rolesActuales.Length; i++)
    {
      nuevoArreglo[i] = rolesActuales[i];
    }
    nuevoArreglo[rolesActuales.Length] = nuevoRol;
    return nuevoArreglo;
  }
}
