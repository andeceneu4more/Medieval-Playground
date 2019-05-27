using UnityEngine;

public class KnightDoorControler : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite doorOpen;
    [SerializeField] public Sprite doorClosed;
    bool isTouched = false;

    public bool isTouchedCheck()
    {
        return isTouched;
    }

    void Start()
    {
        isTouched = false;
        spriteRenderer.sprite = doorClosed;
    }

    void Update()
    {
        if (!isTouched)
        {
            spriteRenderer.sprite = doorClosed;
        }
        else
        {
            spriteRenderer.sprite = doorOpen;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Knight")
        {
            isTouched = true;
            spriteRenderer.sprite = doorOpen;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isTouched = false;
    }
}
