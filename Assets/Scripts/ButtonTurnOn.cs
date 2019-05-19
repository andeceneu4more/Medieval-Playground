using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnOn : MonoBehaviour
{

    private bool visible = false;
    //private bool leftLever = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private ButtonTurnOff buttonTurnOff;
    [SerializeField] PlatformMovement platform;
    [SerializeField] private ButtonTurnOff otherButtonTurnOff;

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
        if (visible == buttonTurnOff.getVisible())
        {
            buttonTurnOff.SetVisible();
            if (otherButtonTurnOff.getVisible() == true)
                platform.ChangeMovementDown();
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        Debug.Log("iese de pe on, " + visible);
        if (collider.gameObject.CompareTag("Player") && visible == true)
        {
            SetVisible();
        }
    }

    


}
