using UnityEngine;

public class DragonDoorControler : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite doorOpen;
    [SerializeField] public Sprite doorClosed;
    public bool isTouched = false;

    void Start()
    {
        isTouched = false;
        spriteRenderer.sprite = doorClosed;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit me");
        if (collision.gameObject.name == "Dragon")
        {
            isTouched = true;
            spriteRenderer.sprite = doorOpen;
        }
    }

}
