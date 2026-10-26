using UnityEngine;
using TMPro;
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
        SpawnInter = Random.Range(10, 20);
    }
  

    // Update is called once per frame
    void Update()
    {
       
        
            timer += Time.deltaTime;
            PointCounter.text = "Points: " + Mathf.Round(Points).ToString();
        if(SpawnInter <= timer)
        {
            Vector3 TopspawnPos = new Vector3(18f, 3.6f, transform.position.z);
            timer = 0f;
            
            Instantiate(Coins, TopspawnPos, transform.rotation);
            TopSpawn = true;
        }
     
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
