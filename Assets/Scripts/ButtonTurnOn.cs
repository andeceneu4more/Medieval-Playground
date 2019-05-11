﻿using System.Collections;
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

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("iesire de pe on");
            SetVisible();
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("enter pe on");
            //SetVisible();
        }
    }


}