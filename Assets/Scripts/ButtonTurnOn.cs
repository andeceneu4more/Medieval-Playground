using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnOn : MonoBehaviour
{

    private bool visible = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private ButtonTurnOff buttonTurnOff;
    [SerializeField] PlatformMovement platform;
    [SerializeField] private ButtonTurnOff otherButtonTurnOff;

    /// <summary>
    /// By default, sprite and collider are inactive
    /// </summary>
    void Start()
    {
        sr.enabled = false;
        ec.enabled = false;
    }

    /// <summary>
    /// Get visibility of button
    /// </summary>
    public bool GetVisible()
    {
        return visible;
    }

    /// <summary>
    /// Switch the button state
    /// </summary>
    public void SetVisible()
    {
        if (visible == false)
            visible = true;
        else
            visible = false;
        OnTurned();
    }

    /// <summary>
    /// Apply the event of touching the button
    /// </summary>
    void OnTurned()
    {
        // Turn on to opposite state
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
        if (visible == buttonTurnOff.GetVisible())
        {
            // Turn off to opposite state
            buttonTurnOff.SetVisible();

            // Move platform to the proper position
            if (otherButtonTurnOff.GetVisible() == true)
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
