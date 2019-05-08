using System;
using UnityEngine;

public class DragonDoorControler : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite doorOpen;
    [SerializeField] public Sprite doorClosed;
    public bool isTouched = false;

    void Start()
    {
        
    }

    void Update()
    {

        if (isTouched)
        {
            spriteRenderer.sprite = doorOpen;
        }

        if (!isTouched)
        {
            spriteRenderer.sprite = doorClosed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Console.WriteLine ("intra");
        if (collision.gameObject.name == "Dragon")
        {
            isTouched = true;
        }
        else
        {
            isTouched = false;
        }

        Update();
    }
}
