using UnityEngine;
using UnityEngine.InputSystem;

public class LoseScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Keyboard.current.enterKey.isPressed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}
