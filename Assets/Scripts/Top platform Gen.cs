using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TopplatformGen : MonoBehaviour
{
    public GameObject topPlat;
    public SpriteRenderer TopPlat;
    public GameObject MidPlat;
    public GameObject BotPlat;
    public CoinSystem HealthSwitch;
    private GameObject ToplastSpawnPlatform;
    private GameObject MidlastSpawnPlatform;
    private GameObject BotLastSpawnPlatform;
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ToplastSpawnPlatform = GameObject.FindWithTag("TopPlatform");
        MidlastSpawnPlatform = GameObject.FindWithTag("MidPlatform");
        BotLastSpawnPlatform = GameObject.FindWithTag("BotPlatform");
        HealthSwitch = FindFirstObjectByType<CoinSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (ToplastSpawnPlatform != null && ToplastSpawnPlatform.transform.position.x <= 6.3f)
        {
            Vector3 TopspawnPos = new Vector3(18f, 2.2f, transform.position.z);

            
            ToplastSpawnPlatform = Instantiate(topPlat, TopspawnPos, transform.rotation);
            
        }
        if (MidlastSpawnPlatform != null && MidlastSpawnPlatform.transform.position.x <= 6.3f)
        {
            Vector3 MidspawnPos = new Vector3(18f, -1.46f, transform.position.z);


            MidlastSpawnPlatform = Instantiate(MidPlat, MidspawnPos, transform.rotation);

        }
        if(BotLastSpawnPlatform != null && BotLastSpawnPlatform.transform.position.x <= 6.3f)
        {
            Vector3 BotspawnPos = new Vector3(18f, -4.6f, transform.position.z);

            BotLastSpawnPlatform = Instantiate(BotPlat, BotspawnPos, transform.rotation);
        }
        if(HealthSwitch.Points <= 90)
        {
            TopPlat.color = Color.red;
        }
    }
}
