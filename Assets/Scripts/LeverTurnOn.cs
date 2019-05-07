using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTurnOn : MonoBehaviour
{
    [SerializeField] private bool visible = false;
    [SerializeField] private SpriteRenderer sr;

    void Start()
    {
        sr.enabled = false;
    }

    void OnMouseDown()
    {
        if (visible == false)
        {
            visible = true;
            sr.enabled = false;
        }
        else
            if (visible == true)
        {
            visible = false;
            sr.enabled = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnMouseDown();
    }
}
