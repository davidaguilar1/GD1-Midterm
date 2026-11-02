using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class Platformdestroyer : MonoBehaviour
{
    private float PlayerHP;
    public TMP_Text PlayerHealth;
    public Slider PlayerHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerHP = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth.text = "Player Health: " + Mathf.Round(PlayerHP).ToString();
        PlayerHealthBar.value = PlayerHP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TopPlatform"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("MidPlatform"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BotPlatform"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            PlayerHP--;
        }
        if(PlayerHP <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
    }
}
