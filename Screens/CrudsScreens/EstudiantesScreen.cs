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
      StyleConsole.Title("ESTUDIANTES", 30);
      StyleConsole.Error("No hay estudiantes cargados.");
      return;
    }
    StyleConsole.Title("LISTA DE ESTUDIANTES", 40);
    for (int i = 0; i < estudiantes.Length; i++)
    {
      StyleConsole.WriteLine($"{i}: {estudiantes[i]}", ConsoleColor.Green);
    }
  }
  public static void AgregarEstudiante()
  {
    StyleConsole.Title("AGREGAR ESTUDIANTE", 30);
    StyleConsole.WriteLine("Escribe los datos necesarios para crear el estudiante", ConsoleColor.Cyan);
    StyleConsole.Write("Nombre:", ConsoleColor.Yellow);
    string nombre = Console.ReadLine()!;
    estudiantes = EstudiantesData.AgregarEstudiante(nombre) ?? new string[0];
  }
  public static void ActualizarEstudiante()
  {
    StyleConsole.Title("ACTUALIZAR ESTUDIANTE", 30);
    StyleConsole.Write("Índice del estudiante:", ConsoleColor.Cyan);
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      string? estudiante = EstudiantesData.CargarEstudiantePorIndice(i);
      if (estudiante == null)
      {
        StyleConsole.Error("No se encontró el estudiante para actualizar.");
        return;
      }
      StyleConsole.Write($"Nombre ({estudiante}):", ConsoleColor.Yellow);
      string nombre = Console.ReadLine()!;
      if (nombre == null || nombre.Trim() == "") nombre = estudiante;
      estudiantes = EstudiantesData.ActualizarEstudiante(i, nombre) ?? new string[0];
    }
    else StyleConsole.Error("El valor es invalido intente nuevamente.");
  }
  public static void EliminarEstudiante()
  {
    StyleConsole.Title("ELIMINAR ESTUDIANTE", 30);
    StyleConsole.WriteLine("Índice del estudiante:", ConsoleColor.Cyan);
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      estudiantes = EstudiantesData.EliminarEstudiante(i) ?? new string[0];
    }
    else StyleConsole.Error("El valor es invalido intente nuevamente.");
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
        AgregarEstudiante();
        break;
      case 3:
        ActualizarEstudiante();
        break;
      case 4:
        EliminarEstudiante();
        break;
      default:
        StyleConsole.Error("Ninguna opción es válida, intente nuevamente");
        break;
    }
    StyleConsole.WriteLine("Presiona cualquier tecla para continuar...", ConsoleColor.Cyan);
    Console.ReadLine();
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title("GESTIÓN DE ESTUDIANTES", 40);
      StyleConsole.WriteLine("1. Ver lista de Estudiantes", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Agregar Estudiante", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Actualizar Estudiante", ConsoleColor.Green);
      StyleConsole.WriteLine("4. Eliminar Estudiante", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }

}