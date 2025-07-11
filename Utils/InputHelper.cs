namespace Ruleta.Utils;

public static class InputHelper
{
  public static int LeerOpcion()
  {
    string? input;
    int op;

    do
    {
      StyleConsole.Write("Ingresa un numero valido: ");
      input = Console.ReadLine();
      Sound.PopSound();
    }
    while (!Int32.TryParse(input, out op));

    return op;
  }

  public static string LeerTexto(string texto, ConsoleColor color = ConsoleColor.Yellow)
  {
    string? input;

    do
    {
      StyleConsole.Write($"{texto}: ", color);
      input = Console.ReadLine();
      Sound.PopSound();
    }
    while (input == null || input.Trim() == "");

    return input;
  }

  public static int LeerNumero(string texto, ConsoleColor color = ConsoleColor.Yellow)
  {
    string? input;
    int numero;

    do
    {
      StyleConsole.Write($"{texto}: ", color);
      input = Console.ReadLine();
      Sound.PopSound();
    }
    while (!Int32.TryParse(input, out numero));

    return numero;
  }

  public static void Continuar()
  {
    StyleConsole.WriteLine("Presiona cualquier tecla para continuar...", ConsoleColor.Cyan);
    Console.ReadKey();
  }
}

