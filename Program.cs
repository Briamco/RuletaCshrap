using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;

internal class Program
{
  private static void Main(string[] args)
  {
    if (!OperatingSystem.IsWindows())
    {
      StyleConsole.Error("No se podran reproducir los sonidos en este sistema operativo.");
    }

    EstudiantesData.CargarEstudiantes();
    ParejasData.CargarParejas();
    ConfigData.CargarCongif();
    RetosData.CargarRetos();

    Screen.ScreenMain();
  }
}