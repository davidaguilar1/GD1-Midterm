using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public AudioSource phase1;
    public AudioSource phase2;
    private CoinSystem BossHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase1.Play();
       
        BossHP = FindAnyObjectByType<CoinSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
