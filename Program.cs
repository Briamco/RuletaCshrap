using Ruleta.Data;
using Ruleta.Screen;

internal class Program
{
  private static void Main(string[] args)
  {
    EstudiantesData.CargarEstudiantes();
    ParejasData.CargarParejas();
    ConfigData.CargarCongif();
    RetosData.CargarRetos();

    Screen.ScreenMain();
  }
}