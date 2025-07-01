using Ruleta.Data;
using Ruleta.Utils;

namespace Ruleta.Screen;

public class Screen
{
  public const int ExitInput = 0;

  public static void ScreenMain()
  {
    while (true)
    {
      MainMenu.Screen(ExitInput);

      int op = InputHelper.LeerOpcion();

      if (op == ExitInput)
      {
        Console.WriteLine("¿Está seguro que desea salir? (S/N)");
        string? confirm = Console.ReadLine()?.Trim().ToUpper();
        if (confirm == "S")
        {
          EstudiantesData.GuardarEstudiantes();
          ParejasData.GuardarParejas();
          ConfigData.GuardarConfig();
          RetosData.GuardarRetos();
          Console.WriteLine("Saliendo del programa...");
          break;
        }
        else
        {
          Console.WriteLine("Operación cancelada. Volviendo al menú principal...");
          continue;
        }
      }

      MainMenu.Navigator(op);
    }
  }
}