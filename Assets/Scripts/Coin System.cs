using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class CoinSystem : MonoBehaviour
{
    public GameObject Coins;
    public Slider BossHealth;
    public int Points;
    public TMP_Text PointCounter;
    public TMP_Text FirstDia;
    public TMP_Text SecondDia;
    public float Toptimer;
    public float Midtimer;
    public float Bottimer;
    public float TopSpawnInter;
    public float MidSpawnInter;
    public float BotSpawnInter;
    public float SpawnGap = 0.5f;
    private float SpawnGapTimer;
    public bool TopSpawn;
    public bool MidSpawn;
    public bool BotSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TopSpawnInter = Random.Range(1, 3);
        MidSpawnInter = Random.Range(2, 4);
        BotSpawnInter = Random.Range(3, 5);
        Points = 100;
        Coins.SetActive(true);
    }
  

    // Update is called once per frame
    void Update()
    {

        BossHealth.value = Points; 
        Toptimer += Time.deltaTime;
        Midtimer += Time.deltaTime;
        Bottimer += Time.deltaTime;
        SpawnGapTimer += Time.deltaTime;
            PointCounter.text = "Boss Health " + Mathf.Round(Points).ToString();
        if (SpawnGapTimer >= SpawnGap && Toptimer >= TopSpawnInter)
        {
            Vector3 TopspawnPos = new Vector3(18f, 3.6f, transform.position.z);
            Toptimer = 0f;
            SpawnGapTimer = 0f;
            
            Instantiate(Coins, TopspawnPos, transform.rotation);
            TopSpawn = true;
            
        }
        else if (SpawnGapTimer >= SpawnGap && Midtimer >= MidSpawnInter)
        {
            Vector3 MidSpawnPos = new Vector3(18f, 0f, transform.position.z);
            Midtimer = 0f;
            SpawnGapTimer = 0f;
            Instantiate(Coins, MidSpawnPos, transform.rotation);
            MidSpawn = true;
        }
        else if (SpawnGapTimer >= SpawnGap && Bottimer >= BotSpawnInter)
        {
            Vector3 BotSpawnPos = new Vector3(18f, -3.6f, transform.position.z);
            Bottimer = 0f;
            SpawnGapTimer = 0f;
            Instantiate(Coins, BotSpawnPos, transform.rotation);
            BotSpawn = true;
        }
     if (TopSpawn == true)
        {
            StartCoroutine(TopSpawnCoin());
        }
     
     if(MidSpawn == true)
        {
            StartCoroutine(MidSpawnCoin());
        }
     if(BotSpawn == true)
        {
            StartCoroutine(BotSpawnCoin());
        }
     if(Points <= 90)
        {
            StartCoroutine(Phase2());
            
        }
    }
    private IEnumerator TopSpawnCoin()
    {
        yield return new();
        if (TopSpawn == true)
        {
            TopSpawnInter = Random.Range(1, 3);
        }
        TopSpawn = false;
    }
    private IEnumerator MidSpawnCoin()
    {
        yield return new();
        if(MidSpawn == true)
        {
            MidSpawnInter = Random.Range(2, 4);
        }
        MidSpawn = false;
    }
    private IEnumerator BotSpawnCoin()
    {
        yield return new();
        if(BotSpawn == true)
        {
            BotSpawnInter = Random.Range(3, 5);
        }
        BotSpawn = false;
    }
    private IEnumerator Phase2()
    {
        yield return new();
        Debug.Log("Phase 2 started");
        Coins.SetActive(false);
        //FirstDia.enabled = true;
        //yield return new WaitForSeconds(4);
        //FirstDia.enabled = false;
        //SecondDia.enabled = true;
        //yield return new WaitForSeconds(4);
        //SecondDia.enabled=false;
        StartCoroutine(TopSpawnCoin2());
        StartCoroutine(MidSpawnCoin2());
        StartCoroutine(BotSpawnCoin2());
        SpawnGap = 0.3f;
        Coins.SetActive(true);
        if (TopSpawn == true)
        {
            StartCoroutine(TopSpawnCoin2());
        }

        if (MidSpawn == true)
        {
            StartCoroutine(MidSpawnCoin2());
        }
        if (BotSpawn == true)
        {
            StartCoroutine(BotSpawnCoin2());
        }
       
    }
    private IEnumerator TopSpawnCoin2()
    {
        yield return new();
        if (TopSpawn == true)
        {
            TopSpawnInter = Random.Range(0.5f, 2);
        }
        TopSpawn = false;
    }
    private IEnumerator MidSpawnCoin2()
    {
        yield return new();
        if (MidSpawn == true)
        {
            MidSpawnInter = Random.Range(1, 2.5f);
        }
        MidSpawn = false;
    }
    private IEnumerator BotSpawnCoin2()
    {
        yield return new();
        if (BotSpawn == true)
        {
            BotSpawnInter = Random.Range(3, 3.5f);
        }
        BotSpawn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Points--;
        }
        
      
    }
}
