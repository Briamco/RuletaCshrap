using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;

public static class EstudiantesMenu
{
  public static string[] estudiantes = EstudiantesData.estudiantes ?? new string[0];

  public static void VerEstudiante()
  {
    if (estudiantes == null || estudiantes.Length == 0)
    {
      Console.WriteLine("No hay estudiantes cargados.");
      return;
    }
    int i = 0;
    foreach (string est in estudiantes)
    {
      Console.WriteLine($"{i}: {est}");
      i++;
    }
  }
  public static void CrearEstudiante()
  {
    Console.WriteLine("Escribe los datos necesarios para Crear el estudiante");

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine()!;

    estudiantes = EstudiantesData.CrearEstudiante(nombre) ?? new string[0];
  }
  public static void EditarEstudiante()
  {
    Console.Write("Indice del estudiante: ");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      string? estudiante = EstudiantesData.CargarEstudiantePorIndice(i);

      if (estudiante == null) return;

      Console.Write($"Nombre ({estudiante}): ");
      string? nombre = Console.ReadLine();

      if (nombre == null) estudiante = nombre ?? estudiante;

      estudiantes = EstudiantesData.ActualizarEstudiante(i, estudiante) ?? new string[0];
    }
    else Console.WriteLine("El valor es invalido intente nuevamente.");
  }
  public static void BorrarEstudiante()
  {
    Console.Write("Indice del estudiante: ");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      estudiantes = EstudiantesData.EliminarEstudiante(i) ?? new string[0];
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
    Console.WriteLine("Presiona cualquier tecla para continuar...");
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