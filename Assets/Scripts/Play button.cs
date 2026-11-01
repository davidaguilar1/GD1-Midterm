using UnityEngine;
using UnityEngine.UI;

public class Playbutton : MonoBehaviour
{
    private string StartScene = "Game";
    private string MainMenu = "How to";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(StartScene);
    }
    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
    }
}
