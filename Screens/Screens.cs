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
        StyleConsole.Title("CONFIRMACIÓN DE SALIDA", 40);
        StyleConsole.WriteLine("¿Está seguro que desea salir? (S/N)", ConsoleColor.Yellow);
        string? confirm = Console.ReadLine()?.Trim().ToUpper();
        if (confirm == "S")
        {
          AnimationHelper.LoadingAnimation("Guardando datos", 1.5);
          EstudiantesData.GuardarEstudiantes();
          ParejasData.GuardarParejas();
          ConfigData.GuardarConfig();
          RetosData.GuardarRetos();
          StyleConsole.Title("SALIENDO DEL PROGRAMA", 40);
          StyleConsole.WriteLine("¡Hasta pronto!", ConsoleColor.Green);
          break;
        }
        else
        {
          StyleConsole.Error("Operación cancelada. Volviendo al menú principal...");
          continue;
        }
      }

      MainMenu.Navigator(op);
    }
  }
}