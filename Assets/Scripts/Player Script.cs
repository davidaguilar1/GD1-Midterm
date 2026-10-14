using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Transform PlayerPos;
    public float PosX;
    public bool Moved;
    public bool IsOn1;
    public bool IsOn2;
    public bool IsOn3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsOn1 = false;
        IsOn2 = true;
        IsOn3 = false;

    }

    // Update is called once per frame
    void Update()
    {
        PosX = PlayerPos.localPosition.x;
        if(IsOn2 == true && Keyboard.current.wKey.wasPressedThisFrame)
        {
            PlayerPos.transform.position = new Vector2(PosX, 3.3f);
            IsOn1 = true;
            IsOn2 = false;
            IsOn3 = false;
            Moved = true;
        }
        else if(IsOn2 == true && Keyboard.current.sKey.wasPressedThisFrame)
        {
            PlayerPos.transform.position = new Vector2(PosX, -3.48f);
            IsOn2 = false;
            IsOn3 = true;
        }
        if(IsOn1 == true && Keyboard.current.sKey.wasPressedThisFrame)
        {
            transform.position = new Vector2(PosX, -0.4f);
            IsOn1 = false;
            IsOn2 = true;
        }
        else if(IsOn1 == true && Keyboard.current.wKey.wasPressedThisFrame)
        {
            PlayerPos.transform.position = new Vector2(PosX, -3.48f);
            IsOn1 = false;
            IsOn3 = true;
        }
        
    }
}
