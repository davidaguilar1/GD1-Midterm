using UnityEngine;

public class PlatformMovment : MonoBehaviour
{
    public Transform PlatForm;
    private float MovSpeed = 11f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlatForm.transform.position += Vector3.left * MovSpeed * Time.deltaTime;
    }
}
