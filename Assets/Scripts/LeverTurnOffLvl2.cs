using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTurnOffLvl2 : MonoBehaviour
{
    private bool visible = true;
    private bool leftLever = true;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private DragonControler dragon;
    [SerializeField] private KnightControler knight;
    [SerializeField] private LeverTurnOnLvl2 otherLever;
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
    /// Get visibility of lever
    /// </summary>
    public bool GetVisible()
    {
        return visible;
    }

    /// <summary>
    /// Switch the lever state
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
    /// Apply the event of touching the left lever
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
        if (visible == otherLever.GetVisible())
        {
            // Turn on to opposite state
            otherLever.SetVisible();

            // Move platform
            platform.ChangeMovementUp();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Dragon")
        {
            if (dragon.getFlipOrientation() == leftLever)
                SetVisible();
        }
        if (collider.gameObject.name == "Knight")
        {
            if (knight.getFlipOrientation() == leftLever)
                SetVisible();
        }
    }
}
