using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnOff : MonoBehaviour
{

    private bool visible = true;
    //private bool leftLever = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private ButtonTurnOn otherButton;
    [SerializeField] PlatformMovement platform;

    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = true;
        ec.enabled = true;
    }

    public bool getVisible()
    {
        return visible;
    }

    public void SetVisible()
    {
        if (visible == false)
            visible = true;
        else
            visible = false;
        OnTurned();
    }

    void OnTurned()
    {
        if (visible == false)
        {
            sr.enabled = false;
            ec.enabled = false;
        }
        else
            if (visible == true)
        {
            sr.enabled = true;
            ec.enabled = true;
        }
        if (visible == otherButton.getVisible())
        {
            otherButton.SetVisible();
            platform.ChangeMovementUp();
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("enter pe off");
            SetVisible();
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("iesire de pe off");
            //SetVisible();
        }
    }
}
