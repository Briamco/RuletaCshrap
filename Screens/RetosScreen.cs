using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;
public static class RetosScreen
{
  public static string[] retos = RetosData.retos ?? new string[0];
  public static void VerRetos()
  {
    if (retos == null)
    {
      Console.WriteLine("No hay retos cargados.");
      return;
    }

    int i = 0;
    foreach (string ret in retos)
    {
      Console.WriteLine($"{i}: {retos[i]}");
      i++;
    }
  }
  public static void AgregarReto()
  {
    Console.WriteLine("Escribe el reto que deceas agregar:");
    string reto = Console.ReadLine()!;

    retos = RetosData.CrearReto(reto) ?? new string[0];
  }
  public static void ActualizarReto()
  {
    Console.Write("Indice del estudiante: ");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {
      string? anteriorReto = RetosData.CargarRetoPorIndice(i);

      if (anteriorReto == null) return;

      Console.Write($"Escribe los cambio al nuevo reto: ");
      string? reto = Console.ReadLine()!;

      if (reto == null || reto.Trim() == "") reto = anteriorReto;

      retos = RetosData.ActualizarReto(i, reto) ?? new string[0];
    }
    else Console.WriteLine("El valor es invalido intente nuevamente.");
  }
  public static void EliminarRetos()
  {
    Console.Write("Indice del estudiante: ");
    string? iInput = Console.ReadLine();

    if (Int32.TryParse(iInput, out int i))
    {

      retos = RetosData.EliminarReto(i) ?? new string[0];
    }
    else Console.WriteLine("El valor es invalido intente nuevamente.");
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
      Console.WriteLine("1.Ver retos");
      Console.WriteLine("2.Agregar un reto");
      Console.WriteLine("3.Actualizar un reto");
      Console.WriteLine("4.Eliminar un reto");
      Console.WriteLine($"{Screen.ExitInput}.Volver");

      int op = InputHelper.LeerOpcion();

      if (op == Screen.ExitInput) break;

      Navigator(op);
    }
  }
}