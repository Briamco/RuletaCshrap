using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Services;
using Ruleta.Utils;
/*
TODO: 
- No se estan guardando los retos.
- Actualizar el historial de parejas al iniciar un contador.
- Buscar otra pereja si esta ya tiene un tiempo establecido.
*/
public static class ContadorMenu
{
  public static string[] parejas = ParejasData.parejasActuales ?? new string[0];
  public static string[]? retos = RetosData.retos ?? new string[0];

  public static void IniciarConteo()
  {
    string[]? parejaArray = RetoService.AsignarPareja(parejas) ?? null;
    if (parejaArray == null || parejaArray.Length == 0)
    {
      Console.WriteLine("No hay parejas disponibles para asignar un reto.");
      return;
    }

    string pareja = parejaArray[0] ?? "";
    int i = Int32.Parse(parejaArray[1]);
    if (pareja == null || pareja.Trim() == "")
    {
      Console.WriteLine("La pareja seleccionada está vacía.");
      return;
    }

    string[] parejaSplit = pareja.Split(" || ");
    if (parejaSplit.Length > 1)
    {
      Console.WriteLine("Esta pareja ya tiene un tiempo establecido.");
      return;
    }

    string? retoAsignado = RetoService.AsignarReto(retos);
    if (retoAsignado == null)
    {
      Console.WriteLine("No se pudo asignar un reto. Intente nuevamente.");
      return;
    }

    Console.WriteLine($"Iniciando contador para la pareja: {pareja}");
    Console.WriteLine($"Reto asignado: {retoAsignado}");
    Console.WriteLine("Presiona cualquier tecla para comenzar el contador...");
    Console.ReadKey(true);

    string? tiempo = ContadorService.IniciarContador(pareja);
    if (tiempo == null)
    {
      Console.WriteLine("No se pudo iniciar el contador. Intente nuevamente.");
      return;
    }

    ParejasData.ActualizarParejaActual(i, $"{pareja} || {tiempo}");
    Console.WriteLine("Tiempo registrado con éxito.");
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
      Console.WriteLine("3.Ver Lista de Historiales");
      Console.WriteLine("4.Cargar Historial de Parejas");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}