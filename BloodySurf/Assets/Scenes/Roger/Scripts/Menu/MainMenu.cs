using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
         Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
       

    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting...");
    }
   
    public void Credits()
    {
 
        SceneManager.LoadScene("Credits");
    }


}
