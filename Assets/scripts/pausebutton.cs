using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pausebutton : MonoBehaviour
{


    public static bool ispaused = false;
    public void PauseGame()
    {
        Invoke(nameof(stoptime), 0.5f);
        
    }
    void stoptime()
    {
        Time.timeScale = 0f;
        ispaused = true;
    }
    public void ResumeGame()
    {
        // Resume the game logic here (e.g., time scale set back to 1)
        // Invoke(nameof(resumetime), 0.5f);
        Time.timeScale = 1f;
        ispaused = false;
    }
   public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        ispaused = false;
    }
}
