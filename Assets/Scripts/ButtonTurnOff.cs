using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnOff : MonoBehaviour
{

    private bool visible = true;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private ButtonTurnOn buttonTurnOn;
    [SerializeField] PlatformMovement platform;

    /// <summary>
    /// By default, sprite and collider are active
    /// </summary>
    void Start()
    {
        sr.enabled = true;
        ec.enabled = true;
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
    /// Apply the event of leaving the button
    /// </summary>
    void OnTurned()
    {
        // Turn off to opposite state
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
        if (visible == buttonTurnOn.GetVisible())
        {
            // Turn on to opposite state
            buttonTurnOn.SetVisible();

            // Move platform
            platform.ChangeMovementUp();
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && visible == true)
        {
            SetVisible();
        }
    }
}
