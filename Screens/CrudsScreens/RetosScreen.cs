using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;
public static class RetosScreen
{
  public static string[] retos = RetosData.retos ?? new string[0];
  public static void VerRetos()
  {
    if (retos == null || retos.Length == 0)
    {
      StyleConsole.Title("RETOS", 30);
      StyleConsole.Error("No hay retos cargados.");
      return;
    }
    StyleConsole.Title("LISTA DE RETOS", 40);
    for (int i = 0; i < retos.Length; i++)
    {
      StyleConsole.WriteLine($"{i}: {retos[i]}", ConsoleColor.Green);
    }
  }
  public static void AgregarReto()
  {
    StyleConsole.Title("AGREGAR RETO", 30);
    StyleConsole.Write("Escribe el reto que deseas agregar:", ConsoleColor.Cyan);
    string reto = Console.ReadLine()!;
    retos = RetosData.CrearReto(reto) ?? new string[0];
  }
  public static void ActualizarReto()
  {
    StyleConsole.Title("ACTUALIZAR RETO", 30);
    StyleConsole.Write("Índice del reto:", ConsoleColor.Cyan);
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      string? anteriorReto = RetosData.CargarRetoPorIndice(i);
      if (anteriorReto == null)
      {
        StyleConsole.Error("No se encontró el reto para actualizar.");
        return;
      }
      StyleConsole.Write("Escribe los cambios al nuevo reto:", ConsoleColor.Cyan);
      string? reto = Console.ReadLine()!;
      if (reto == null || reto.Trim() == "") reto = anteriorReto;
      retos = RetosData.ActualizarReto(i, reto) ?? new string[0];
    }
    else StyleConsole.Error("El valor es invalido intente nuevamente.");
  }
  public static void EliminarRetos()
  {
    StyleConsole.Title("ELIMINAR RETO", 30);
    StyleConsole.Write("Índice del reto:", ConsoleColor.Cyan);
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      retos = RetosData.EliminarReto(i) ?? new string[0];
    }
    else StyleConsole.Error("El valor es invalido intente nuevamente.");
  }
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        VerRetos();
        break;
      case 2:
        AgregarReto();
        break;
      case 3:
        ActualizarReto();
        break;
      case 4:
        EliminarRetos();
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
      StyleConsole.Title("GESTIÓN DE RETOS", 40);
      StyleConsole.WriteLine("1. Ver retos", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Agregar un reto", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Actualizar un reto", ConsoleColor.Green);
      StyleConsole.WriteLine("4. Eliminar un reto", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}