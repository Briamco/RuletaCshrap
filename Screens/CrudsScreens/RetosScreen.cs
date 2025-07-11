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
      StyleConsole.WriteLine($"{i + 1}: {retos[i]}", ConsoleColor.Green);
    }
  }
  public static void AgregarReto()
  {
    StyleConsole.Title("AGREGAR RETO", 30);
    string reto = InputHelper.LeerTexto("Escribe el reto que deseas agregar", ConsoleColor.Cyan);
    if (reto == null || reto.Trim() == "")
    {
      StyleConsole.Error("El reto no puede estar vacío.");
      return;
    }
    retos = RetosData.CrearReto(reto) ?? new string[0];
  }
  public static void ActualizarReto()
  {
    StyleConsole.Title("ACTUALIZAR RETO", 30);
    StyleConsole.Write("Índice del reto:", ConsoleColor.Cyan);
    int? i = InputHelper.LeerNumero("Índice del reto", ConsoleColor.Cyan) - 1;

    string? anteriorReto = RetosData.CargarRetoPorIndice(i.Value);
    if (anteriorReto == null)
    {
      StyleConsole.Error("No se encontró el reto para actualizar.");
      return;
    }
    StyleConsole.WriteLine($"Reto actual: {anteriorReto}", ConsoleColor.Yellow);
    string? reto = InputHelper.LeerTexto("Nuevo reto", ConsoleColor.Cyan);
    if (reto == null || reto.Trim() == "") reto = anteriorReto;
    retos = RetosData.ActualizarReto(i.Value, reto) ?? new string[0];

  }
  public static void EliminarRetos()
  {
    StyleConsole.Title("ELIMINAR RETO", 30);
    StyleConsole.Write("Índice del reto:", ConsoleColor.Cyan);
    int? i = InputHelper.LeerNumero("Índice del reto", ConsoleColor.Cyan) - 1;

    retos = RetosData.EliminarReto(i.Value) ?? new string[0];
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
    InputHelper.Continuar();
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