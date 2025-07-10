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
          StyleConsole.Title("GUARDANDO DATOS", 40);
          StyleConsole.WriteLine("Guardando estudiantes...", ConsoleColor.Cyan);
          EstudiantesData.GuardarEstudiantes();
          StyleConsole.WriteLine("Guardando parejas...", ConsoleColor.Cyan);
          ParejasData.GuardarParejas();
          StyleConsole.WriteLine("Guardando configuración...", ConsoleColor.Cyan);
          ConfigData.GuardarConfig();
          StyleConsole.WriteLine("Guardando retos...", ConsoleColor.Cyan);
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