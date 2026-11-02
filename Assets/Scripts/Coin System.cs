using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class CoinSystem : MonoBehaviour
{
    private SoundManage soundManager;
    private CoinMovment coinMovement;
    public GameObject Coins;
    public Slider BossHealth;
    public int Points;
    public TMP_Text PointCounter;
    public TMP_Text FirstDia;
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
    

    private bool phase2Started = false; // Added to prevent Phase 2 from looping every frame

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TopSpawnInter = Random.Range(1, 3);
        MidSpawnInter = Random.Range(2, 4);
        BotSpawnInter = Random.Range(3, 5);
        Points = 100;
        Coins.SetActive(true);
        soundManager = FindAnyObjectByType<SoundManage>();
       
    }

    // Update is called once per frame
    void Update()
    {
        coinMovement = FindFirstObjectByType<CoinMovment>();
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

        if (MidSpawn == true)
        {
            StartCoroutine(MidSpawnCoin());
        }

        if (BotSpawn == true)
        {
            StartCoroutine(BotSpawnCoin());
        }

        if (Points <= 50 && !phase2Started)
        {
            phase2Started = true;
            StartCoroutine(Phase2());
        }
        if(Points <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private IEnumerator TopSpawnCoin()
    {
        yield return null; 
        if (TopSpawn == true)
        {
            TopSpawnInter = Random.Range(1, 3);
        }
        TopSpawn = false;
    }

    private IEnumerator MidSpawnCoin()
    {
        yield return null; 
        if (MidSpawn == true)
        {
            MidSpawnInter = Random.Range(2, 4);
        }
        MidSpawn = false;
    }

    private IEnumerator BotSpawnCoin()
    {
        yield return null; 
        if (BotSpawn == true)
        {
            BotSpawnInter = Random.Range(3, 5);
        }
        BotSpawn = false;
    }

    private IEnumerator Phase2()
    {
        yield return null; 
        Debug.Log("Phase 2 started");
        Coins.SetActive(false);
        soundManager.phase1.Stop();
        soundManager.phase2.Play();
        FirstDia.enabled = true;
        yield return new WaitForSeconds(4);
        FirstDia.enabled = false;
        StartCoroutine(TopSpawnCoin2());
        StartCoroutine(MidSpawnCoin2());
        StartCoroutine(BotSpawnCoin2());
        SpawnGap = 0.1f;
        Coins.SetActive(true);
        coinMovement = FindFirstObjectByType<CoinMovment>();
        if (coinMovement != null)
        {
            coinMovement.MovSpeed = 20f;
        }
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
        yield return null; 
        if (TopSpawn == true)
        {
            TopSpawnInter = Random.Range(0.5f, 2);
        }
        TopSpawn = false;
    }

    private IEnumerator MidSpawnCoin2()
    {
        yield return null; 
        if (MidSpawn == true)
        {
            MidSpawnInter = Random.Range(1, 2.5f);
        }
        MidSpawn = false;
    }

    private IEnumerator BotSpawnCoin2()
    {
        yield return null;
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
            Points -= 2;
            
        }
        
    }
}