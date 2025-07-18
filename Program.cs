using Ruleta.Data;
using Ruleta.Screen;
using Ruleta.Utils;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.Clear();
    StyleConsole.WriteLine(@"
                            ,--,                     ,----,                          ,---, 
                         ,---.'|                   ,/   .`|             ,----..   ,`--.' | 
,-.----.                 |   | :       ,---,.    ,`   .'  :   ,---,.   /   /   \  |   :  : 
\    /  \           ,--, :   : |     ,'  .' |  ;    ;     / ,'  .' |  /   .     : |   |  ' 
;   :    \        ,'_ /| |   ' :   ,---.'   |.'___,/    ,',---.'   | .   /   ;.  \'   :  | 
|   | .\ :   .--. |  | : ;   ; '   |   |   .'|    :     | |   |   .'.   ;   /  ` ;;   |.'  
.   : |: | ,'_ /| :  . | '   | |__ :   :  |-,;    |.';  ; :   :  |-,;   |  ; \ ; |'---'    
|   |  \ : |  ' | |  . . |   | :.'|:   |  ;/|`----'  |  | :   |  ;/||   :  | ; | '         
|   : .  / |  | ' |  | | '   :    ;|   :   .'    '   :  ; |   :   .'.   |  ' ' ' :         
;   | |  \ :  | | :  ' ; |   |  ./ |   |  |-,    |   |  ' |   |  |-,'   ;  \; /  |         
|   | ;\  \|  ; ' |  | ' ;   : ;   '   :  ;/|    '   :  | '   :  ;/| \   \  ',  /          
:   ' | \.':  | : ;  ; | |   ,/    |   |    \    ;   |.'  |   |    \  ;   :    /           
:   : :-'  '  :  `--'   \'---'     |   :   .'    '---'    |   :   .'   \   \ .'            
|   |.'    :  ,      .-./          |   | ,'               |   | ,'      `---`              
`---'       `--`----'              `----'                 `----'                           
                                                                                           
", ConsoleColor.Cyan);
    if (!OperatingSystem.IsWindows())
    {
      StyleConsole.Error("No se podran reproducir los sonidos en este sistema operativo.");
    }

    AnimationHelper.LoadingAnimation("Cargando", 1.5);

    EstudiantesData.CargarEstudiantes();
    ParejasData.CargarParejas();
    ConfigData.CargarCongif();
    RetosData.CargarRetos();

    Screen.ScreenMain();
    Console.ResetColor();
  }
}