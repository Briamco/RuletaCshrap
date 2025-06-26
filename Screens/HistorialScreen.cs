using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;

public static class HistorialScreen
{
  public static string[][] parejas = ParejasData.parejas ?? new string[0][];
  public static void ListaDeHistoriales()
  {
    if (parejas == null || parejas.Length == 0)
    {
      Console.WriteLine("No hay estudiantes cargados.");
      return;
    }
    int i = 0;
    foreach (string[] par in parejas)
    {
      Console.WriteLine($"{i}: historial_{i}");
      i++;
    }
  }
  public static void VerHistorial()
  {
    Console.Write("Indice del estudiante: ");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      string[]? parejas = ParejasData.CargarParejaPorIndice(i) ?? new string[0];

      int j = 0;

      foreach (string par in parejas)
      {
        Console.WriteLine($"{j}: {par}");
        j++;
      }
    }
    else Console.WriteLine("El valor es invalido intente nuevamente.");
  }
  public static void VerHistorialActual()
  {
    string[]? parejas = ParejasData.parejasActuales ?? new string[0];

    if (parejas == null)
    {
      Console.WriteLine("No hay historial.");
      return;
    }

    int i = 0;

    foreach (string par in parejas)
    {
      Console.WriteLine($"{i}: {parejas[i]}");
      i++;
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
      Console.WriteLine("1.Ver lista de Historiales");
      Console.WriteLine("2.Ver un historial especifico");
      Console.WriteLine("3.Ver un historial actual");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}