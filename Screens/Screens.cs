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
        EstudiantesData.GuardarEstudiantes();
        Console.WriteLine("Datos Guardados, Gracias...");
        break;
      }

      MainMenu.Navigator(op);
    }
  }
}