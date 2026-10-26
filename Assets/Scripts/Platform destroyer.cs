using UnityEngine;

public class Platformdestroyer : MonoBehaviour
{
    public CoinSystem Point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Point = FindFirstObjectByType<CoinSystem>();
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
            Point.Points--;
        }
    }
}
