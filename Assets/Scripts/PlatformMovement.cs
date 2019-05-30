using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private bool moveUp;

    private bool moveDown;

    private Vector3 posLeverOFF;

    private Vector3 posLeverON;

    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform transformLeverOFF;

    [SerializeField]
    private Transform transformLeverON;

    /// <summary>
    /// Initially platform stands
    /// </summary>
    void Start()
    {
        posLeverOFF = transformLeverOFF.localPosition;
        posLeverON = transformLeverON.localPosition;
        nextPos = posLeverON;
        moveDown = false;
        moveUp = false;
    }

    /// <summary>
    /// Change direction of platform down
    /// </summary>
    public void ChangeMovementDown()
    {
        if (moveDown == false)
        {
            moveDown = true;
            moveUp = false;
        }
        else
        {
            moveDown = false;
        }
    }

    /// <summary>
    /// Change direction of platform up
    /// </summary>
    public void ChangeMovementUp()
    {
        if (moveUp == false)
        {
            moveUp = true;
            moveDown = false;
        }
        else
        {
            moveUp = false;
        }
    }

    /// <summary>
    /// Check direction every frame
    /// </summary>
    void Update()
    {
        if (moveUp == true)
        {
            MoveUp();
        }
        if (moveDown == true)
        {
            MoveDown();
        }
    }

    /// <summary>
    /// Move platform from current position to upper bound
    /// </summary>
    public void MoveUp()
    {
        transformLeverOFF.localPosition = Vector3.MoveTowards(transformLeverOFF.localPosition, posLeverON, speed * Time.deltaTime);
    }

    /// <summary>
    /// Move platform from current position to lower bound
    /// </summary>
    public void MoveDown()
    {
        transformLeverOFF.localPosition = Vector3.MoveTowards(transformLeverOFF.localPosition, posLeverOFF, speed * Time.deltaTime);
    }
}
