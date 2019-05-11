using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnOn : MonoBehaviour
{

    private bool visible = false;
    //private bool leftLever = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private ButtonTurnOff otherButton;
    [SerializeField] PlatformMovement platform;

    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = false;
        ec.enabled = false;
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
            platform.ChangeMovementDown();
        }
    }

    /*void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("intra pe on, visible = " + visible);
        if (collider.gameObject.CompareTag("Player") && visible == false)
        {
            SetVisible();
        }
    }*/

    void OnCollisionExit2D(Collision2D collider)
    {
        Debug.Log("iese de pe on, " + visible);
        if (collider.gameObject.CompareTag("Player") && visible == true)
        {
            SetVisible();
        }
    }

    


}
