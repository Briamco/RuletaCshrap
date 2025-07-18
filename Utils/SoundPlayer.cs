using System.Media;

namespace Ruleta.Utils;

class Sound
{
  public static void PlaySound(string soundFilePath, bool loop = false)
  {
    if (string.IsNullOrEmpty(soundFilePath))
    {
      throw new ArgumentException("El archivo de sonido no puede ser nulo o vacío.", nameof(soundFilePath));
    }

    try
    {
      if (OperatingSystem.IsWindows())
      {
        SoundPlayer player = new SoundPlayer(soundFilePath);
        player.Load();
        if (loop) player.PlayLooping();
        else player.Play();
      }
    }
    catch (Exception ex)
    {
      StyleConsole.Error($"Error al reproducir el sonido: {ex.Message}");
    }
  }

  public static void StopSound()
  {
    try
    {
      if (OperatingSystem.IsWindows())
      {
        SoundPlayer player = new SoundPlayer();
        player.Stop();
      }
    }
    catch (Exception ex)
    {
      StyleConsole.Error($"Error al detener el sonido: {ex.Message}");
    }
  }

  public static void PopSound() =>
    PlaySound("Media/Sound/pop-1.wav");

  public static void RuletaSound() =>
    PlaySound("Media/Sound/spinner.WAV");

  public static void StopRuletaSound() =>
    PlaySound("Media/Sound/spinner.WAV");

  public static void ClockSound() =>
    PlaySound("Media/Sound/Old-Clock-sound-effect.wav", true);

  public static void StopClockSound() =>
    PlaySound("Media/Sound/Shot_clock.WAV");
}