namespace Ruleta.Models;

public class Config
{
  public string DevRol { get; set; } = "Desarrollador en Vivo";
  public string FacRol { get; set; } = "Facilitador";

  public override string ToString()
  {
    return $"{DevRol}, {FacRol}";
  }
}