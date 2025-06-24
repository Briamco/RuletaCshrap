using Ruleta.Data;
using Ruleta.Models;
using Ruleta.Screen;
using Ruleta.Utils;

public static class EstudiantesMenu
{
  public static Estudiante[] estudiantes = EstudiantesData.estudiantes ?? new Estudiante[0];

  public static void VerEstudiante()
  {
    if (estudiantes == null || estudiantes.Length == 0)
    {
      Console.WriteLine("No hay estudiantes cargados.");
      return;
    }
    int i = 0;
    foreach (Estudiante est in estudiantes)
    {
      Console.WriteLine($"{i}: {est.Nombre} - Roles: {string.Join(", ", est.Rol ?? new string[0])}");
      i++;
    }
  }
  public static void CrearEstudiante()
  {
    Console.WriteLine("Escribe los datos necesarios para Crear el estudiante");

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine()!;

    Estudiante estudiante = new Estudiante { Nombre = nombre };

    estudiantes = EstudiantesData.CrearEstudiante(estudiante) ?? new Estudiante[0];
  }
  public static void EditarEstudiante()
  {
    Console.Write("Indice del estudiante: ");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      Estudiante? estudiante = EstudiantesData.CargarEstudiantePorIndice(i);

      if (estudiante == null) return;

      Console.Write($"Nombre ({estudiante.Nombre}): ");
      string? nombre = Console.ReadLine();

      if (!string.IsNullOrEmpty(nombre)) estudiante.Nombre = nombre;

      estudiantes = EstudiantesData.ActualizarEstudiante(i, estudiante) ?? new Estudiante[0];
    }
    else Console.WriteLine("El valor es invalido intente nuevamente.");
  }
  public static void BorrarEstudiante()
  {
    Console.Write("Indice del estudiante: ");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      estudiantes = EstudiantesData.EliminarEstudiante(i) ?? new Estudiante[0];
    }
    else Console.WriteLine("El valor es invalido intente nuevamente.");
  }

  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        VerEstudiante();
        break;
      case 2:
        CrearEstudiante();
        break;
      case 3:
        EditarEstudiante();
        break;
      case 4:
        BorrarEstudiante();
        break;
      default:
        Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
        break;
    }
    Console.ReadLine();
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine("1.Ver lista de Estudiante");
      Console.WriteLine("2.Agregar Estudiante");
      Console.WriteLine("3.Actualizar Estudiante");
      Console.WriteLine("4.Eleminar Estudiante");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }

}