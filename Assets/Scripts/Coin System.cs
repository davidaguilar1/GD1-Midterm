using UnityEngine;
using TMPro;
using System.Collections;
public class CoinSystem : MonoBehaviour
{
    public GameObject Coins;
    public int Points;
    public TMP_Text PointCounter;
    public float timer;
    public float SpawnInter;
    public bool TopSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnInter = Random.Range(1, 3);
    }
  

    // Update is called once per frame
    void Update()
    {
       
        
            timer += Time.deltaTime;
            PointCounter.text = "Points: " + Mathf.Round(Points).ToString();
        if(timer >= SpawnInter)
        {
            Vector3 TopspawnPos = new Vector3(18f, 3.6f, transform.position.z);
            timer = 0f;
            
            Instantiate(Coins, TopspawnPos, transform.rotation);
            TopSpawn = true;
            
        }
     if(TopSpawn == true)
        {
            StartCoroutine(SpawnCoin());
        }
     if(Points >= 10)
        {
            StopCoroutine(SpawnCoin());
            StartCoroutine(Phase2());
            
        }
    }
    private IEnumerator SpawnCoin()
    {
        yield return new();
        if (TopSpawn == true)
        {
            SpawnInter = Random.Range(1, 3);
        }
        TopSpawn = false;
    }
    private IEnumerator Phase2()
    {
        yield return new();
        if(TopSpawn == true)
        {
            SpawnInter = Random.Range(0.5f, 2);
        }
        TopSpawn = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Points++;
        }
        
      
    }
}
