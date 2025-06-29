using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Services;
using Ruleta.Utils;

public static class ContadorMenu
{
  static public string[] parejas = ParejasData.parejasActuales ?? new string[0];
  public static void IniciarConteo()
  {
    Console.WriteLine("Escribe el indice de la pareja que quieres iniciar el contador");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      string? pareja = parejas[i] ?? string.Empty;

      if (string.IsNullOrEmpty(pareja))
      {
        Console.WriteLine("No se pudo iniciar el contador. Intente nuevamente.");
        return;
      }

      string[] parejaSplit = pareja.Split(" || ");

      if (parejaSplit.Length > 1)
      {
        Console.WriteLine("Esta pareja ya tiene un tiempo establecido.");
        return;
      }
      string? tiempo = ContadorService.IniciarContador(pareja);

      if (string.IsNullOrEmpty(tiempo))
      {
        Console.WriteLine("No se pudo iniciar el contador. Intente nuevamente.");
        return;
      }
      ParejasData.ActualizarParejaActual(i, $"{pareja} || {tiempo}");
    }
    else
    {
      Console.WriteLine("El valor es invalido intente nuevamente.");
    }
  }
  public static void VerTabla()
  {
    if (parejas == null || parejas.Length == 0)
    {
      Console.WriteLine("No hay parejas cargadas.");
      return;
    }
    string[][] parejasTiempo = new string[parejas.Length][];
    for (int i = 0; i < parejas.Length; i++)
    {
      parejasTiempo[i] = parejas[i].Split(" || ");
    }
    for (int i = 0; i < parejasTiempo.Length; i++)
    {
      if (parejasTiempo[i].Length == 2)
      {
        Console.WriteLine($"{i}: {parejasTiempo[i][0]} || Tiempo: {parejasTiempo[i][1]}");
      }
      else
      {
        Console.WriteLine($"{i}: {parejasTiempo[i][0]} || Tiempo: No iniciado");
      }
    }
  }
  public static void CargarHistorialDePareja()
  {
    while (true)
    {
      Console.WriteLine("1.Cargar Historial de Parejas");
      Console.WriteLine("2.Cargar Pareja Actual");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Console.Clear();
      switch (op)
      {
        case 1:
          Console.WriteLine("Escribe el indice del historial que quieres cargar");
          string? iInput = Console.ReadLine();

          if (Int32.TryParse(iInput, out int i))
          {
            string[]? historialParejas = ParejasData.CargarParejaPorIndice(i);

            if (historialParejas == null || historialParejas.Length == 0)
            {
              Console.WriteLine("No se pudo cargar el historial. Intente nuevamente.");
              return;
            }
            parejas = historialParejas;
          }
          else
          {
            Console.WriteLine("El valor es invalido intente nuevamente.");
          }
          break;
        case 2:
          parejas = ParejasData.parejasActuales ?? new string[0];
          break;
        default:
          Console.WriteLine("Ninguna opcion es valida, intente nuevamente");
          break;
      }
      break;
    }
  }
  public static void Navigator(int op)
  {
    Console.Clear();
    switch (op)
    {
      case 1:
        IniciarConteo();
        break;
      case 2:
        VerTabla();
        break;
      case 3:
        HistorialScreen.ListaDeHistoriales();
        break;
      case 4:
        CargarHistorialDePareja();
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
      Console.WriteLine("1.Iniciar Contador");
      Console.WriteLine("2.Ver Tabla de Contadores");
      Console.WriteLine("3.Cargar Historial de Parejas");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}