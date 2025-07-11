using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;

public static class HistorialScreen
{
  public static string[][] historial = ParejasData.parejas ?? new string[0][];
  public static void ListaDeHistoriales()
  {
    if (historial == null || historial.Length == 0)
    {
      StyleConsole.Title("HISTORIALES", 30);
      StyleConsole.Error("No hay estudiantes cargados.");
      return;
    }
    StyleConsole.Title("LISTA DE HISTORIALES", 40);
    for (int i = 0; i < historial.Length; i++)
    {
      StyleConsole.WriteLine($"{i + 1}: historial_{i}", ConsoleColor.Green);
    }
  }
  public static void VerHistorial()
  {
    StyleConsole.Title("VER HISTORIAL", 30);
    StyleConsole.Write("Índice del historial:", ConsoleColor.Cyan);
    int? i = InputHelper.LeerNumero("Índice del historial", ConsoleColor.Cyan) - 1;

    string[]? parejas = ParejasData.CargarParejaPorIndice(i.Value) ?? new string[0];
    if (parejas.Length == 0)
    {
      StyleConsole.Error("No se encontró el historial.");
      return;
    }
    StyleConsole.Title($"HISTORIAL {i}", 40);
    for (int j = 0; j < parejas.Length; j++)
    {
      StyleConsole.WriteLine($"{j + 1}: {parejas[j]}", ConsoleColor.Green);
    }

  }
  public static void VerHistorialActual()
  {
    string[]? parejas = ParejasData.parejasActuales ?? new string[0];
    if (parejas == null || parejas.Length == 0)
    {
      StyleConsole.Title("HISTORIAL ACTUAL", 30);
      StyleConsole.WriteLine("No hay historial.", ConsoleColor.Red);
      return;
    }
    StyleConsole.Title("HISTORIAL ACTUAL", 40);
    for (int i = 0; i < parejas.Length; i++)
    {
      StyleConsole.WriteLine($"{i + 1}: {parejas[i]}", ConsoleColor.Green);
    }
  }
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        ListaDeHistoriales();
        break;
      case 2:
        VerHistorial();
        break;
      case 3:
        VerHistorialActual();
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
      StyleConsole.Title("GESTIÓN DE HISTORIALES", 40);
      StyleConsole.WriteLine("1. Ver lista de Historiales", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Ver un historial específico", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Ver un historial actual", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}