using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTurnOff : MonoBehaviour
{
    private bool visible = true;
    private bool leftLever = false;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EdgeCollider2D ec;
    [SerializeField] private DragonControler dragon;
    [SerializeField] private KnightControler knight;
    [SerializeField] private LeverTurnOn otherLever;
    [SerializeField] PlatformMovement platform;

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
        if (visible == otherLever.getVisible())
        {
            otherLever.SetVisible();
            platform.ChangeMovement();
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
