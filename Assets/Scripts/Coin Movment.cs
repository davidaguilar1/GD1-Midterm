using UnityEngine;

public class CoinMovment : MonoBehaviour
{
    public Transform Coin;
    public float MovSpeed = 12f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Coin.transform.position += Vector3.left * MovSpeed * Time.deltaTime;  
    }
}
