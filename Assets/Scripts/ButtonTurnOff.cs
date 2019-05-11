using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnOff : MonoBehaviour
{

    private bool visible = true;
    //private bool leftLever = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private ButtonTurnOn buttonTurnOn;
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
        if (visible == buttonTurnOn.getVisible())
        {
            buttonTurnOn.SetVisible();
            platform.ChangeMovementUp();
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("intra pe off, visible = " + visible);
        if (collider.gameObject.CompareTag("Player") && visible == true)
        {
            SetVisible();
        }
    }

    /*void OnCollisionExit2D(Collision2D collider)
    {
        Debug.Log("iese de pe off, visible = " + visible);
        if (collider.gameObject.CompareTag("Player") && visible == false)
        {
            SetVisible();
        }
    }*/
}
