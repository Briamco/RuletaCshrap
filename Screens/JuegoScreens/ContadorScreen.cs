using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Services;
using Ruleta.Utils;

public static class ContadorMenu
{
  public static string[] parejas = ParejasData.parejasActuales ?? new string[0];
  public static string[]? retos = RetosData.retos ?? new string[0];
  public static int iHis = -1;

  public static void IniciarConteo()
  {
    StyleConsole.Title("CONTADOR", 30);

    string[]? parejaArray = RetoService.AsignarPareja(parejas) ?? null;
    if (parejaArray != null) InputHelper.Continuar();
    if (parejaArray == null || parejaArray.Length == 0)
    {
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.Error("No hay parejas disponibles para asignar un reto.");
      return;
    }

    string pareja = parejaArray[0] ?? "";
    int i = int.Parse(parejaArray[1]);
    if (pareja == null || pareja.Trim() == "")
    {
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.Error("La pareja seleccionada está vacía.");
      return;
    }

    string[] parejaSplit = pareja.Split(" || ");
    if (parejaSplit.Length > 1)
    {
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.WriteLine("Esta pareja ya tiene un tiempo establecido.", ConsoleColor.Yellow);
      return;
    }

    string? retoAsignado = RetoService.AsignarReto(retos);
    if (retoAsignado == null)
    {
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.Error("No se pudo asignar un reto. Intente nuevamente.");
      return;
    }

    StyleConsole.WriteLine("Presiona cualquier tecla para comenzar el contador...", ConsoleColor.Cyan);
    Console.ReadKey(true);

    string? tiempo = ContadorService.IniciarContador(pareja);
    if (tiempo == null)
    {
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.Error("No se pudo iniciar el contador. Intente nuevamente.");
      return;
    }

    if (iHis == -1) parejas = ParejasData.ActualizarParejaActual(i, $"{pareja} || {tiempo}") ?? new string[0];
    else
    {
      parejas = ParejasData.ActualizarPareja(iHis, i, $"{pareja} || {tiempo}") ?? new string[0];
      ParejasData.GuardarParejasPasadas(iHis);
    }
    StyleConsole.Title("CONTADOR", 30);
    StyleConsole.WriteLine("Tiempo registrado con éxito.", ConsoleColor.Green);
  }

  public static void VerTabla()
  {
    if (parejas == null || parejas.Length == 0)
    {
      StyleConsole.Title("CONTADOR", 30);
      StyleConsole.Error("No hay parejas cargadas.");
      return;
    }
    string[][] parejasTiempo = new string[parejas.Length][];
    for (int i = 0; i < parejas.Length; i++)
    {
      parejasTiempo[i] = parejas[i].Split(" || ");
    }
    StyleConsole.Title("TABLA DE CONTADORES", 40);
    for (int i = 0; i < parejasTiempo.Length; i++)
    {
      if (parejasTiempo[i].Length == 2)
      {
        StyleConsole.WriteLine($"{i}: {parejasTiempo[i][0]} || Tiempo: {parejasTiempo[i][1]}", ConsoleColor.Green);
      }
      else
      {
        StyleConsole.WriteLine($"{i}: {parejasTiempo[i][0]} || Tiempo: No iniciado", ConsoleColor.Yellow);
      }
    }
  }
  public static void CargarHistorialDePareja()
  {
    while (true)
    {
      StyleConsole.Title("HISTORIAL DE PAREJAS", 40);
      StyleConsole.WriteLine("1. Cargar Historial de Parejas", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Cargar Pareja Actual", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Mostrar historial de parejas", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Console.Clear();
      switch (op)
      {
        case 1:
          int? i = InputHelper.LeerNumero("Escribe el indice del historial que quieres cargar", ConsoleColor.Cyan);

          string[]? historialParejas = ParejasData.CargarParejaPorIndice(i.Value);
          iHis = i.Value;

          if (historialParejas == null || historialParejas.Length == 0)
          {
            StyleConsole.WriteLine("No se pudo cargar el historial. Intente nuevamente.", ConsoleColor.Red);
            return;
          }
          parejas = historialParejas;
          break;
        case 2:
          iHis = -1;
          parejas = ParejasData.parejasActuales ?? new string[0];
          StyleConsole.WriteLine("Parejas actuales cargada.", ConsoleColor.Green);
          break;
        case 3:
          HistorialScreen.ListaDeHistoriales();
          break;
        default:
          StyleConsole.WriteLine("Ninguna opcion es valida, intente nuevamente", ConsoleColor.Red);
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
        CargarHistorialDePareja();
        break;
      default:
        StyleConsole.WriteLine("Ninguna opcion es valida, intente nuevamente", ConsoleColor.Red);
        break;
    }
    InputHelper.Continuar();
  }
  public static void MainScreen()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title("CONTADOR DE PAREJAS");
      StyleConsole.WriteLine("1. Iniciar Contador", ConsoleColor.Green);
      StyleConsole.WriteLine("2. Ver Tabla de Contadores", ConsoleColor.Green);
      StyleConsole.WriteLine("3. Cargar Historial de Parejas", ConsoleColor.Green);
      StyleConsole.WriteLine($"{Screen.ExitInput}. Volver", ConsoleColor.Red);

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}