using UnityEngine;

public class KnightDoorControler : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite doorOpen;
    [SerializeField] public Sprite doorClosed;
    bool isTouched = false;

    /// <summary>
    /// Called to check if level is changing
    /// </summary>
    public bool isTouchedCheck()
    {
        return isTouched;
    }

    /// <summary>
    /// Initially door is closed
    /// </summary>
    void Start()
    {
        isTouched = false;
        spriteRenderer.sprite = doorClosed;
    }

    /// <summary>
    /// Check every frame if door was touched
    /// </summary>
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
