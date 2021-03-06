using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
  public static void LoadFirstGameScene()
  {
    SceneManager.LoadScene("Scene_1");
  }

  public void Exit()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
  }

  public void RestartBtn()
  {
    RunTimeScale();
    GameManager.Instance.Reload();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  private static void PauseTimeScale()
  {
    Time.timeScale = 0f;
  }

  private static void RunTimeScale()
  {
    Time.timeScale = 1f;
  }
}