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
    }
    while (!Int32.TryParse(input, out op));

    return op;
  }
}

