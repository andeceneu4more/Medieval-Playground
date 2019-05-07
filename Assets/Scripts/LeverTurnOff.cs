using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTurnOff : MonoBehaviour
{
    [SerializeField] private static bool visible = true;
    [SerializeField] private SpriteRenderer sr;

    void Start()
    {
        if (visible == true)
            sr.enabled = true;
        else
            if (visible == false)
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
