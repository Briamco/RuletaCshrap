namespace Ruleta.Utils;

class ValidationHelper
{
  public static bool ValidarIndice(int i, string[]? array, string type)
  {
    if (array == null || array.Length == 0)
    {
      Console.WriteLine($"No hay {type} cargados.");
      return false;
    }

    if (i < 0 || i >= array.Length)
    {
      Console.WriteLine("Índice fuera de rango.");
      return false;
    }
    return true;
  }
  public static bool ValidarIndiceArrayDoble(int i, string[][]? array, string type)
  {
    if (array == null || array.Length == 0)
    {
      Console.WriteLine($"No hay {type} cargados.");
      return false;
    }

    if (i < 0 || i >= array.Length)
    {
      Console.WriteLine("Índice fuera de rango.");
      return false;
    }

    return true;
  }
}