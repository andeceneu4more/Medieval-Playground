using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //[SerializeField] private bool moveOn;
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

    // Start is called before the first frame update
    void Start()
    {
        posLeverOFF = transformLeverOFF.localPosition;
        posLeverON = transformLeverON.localPosition;
        nextPos = posLeverON;
        moveDown = false;
        moveUp = false;
    }

    // Update is called once per frame

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

    public void MoveUp()
    {
        transformLeverOFF.localPosition = Vector3.MoveTowards(transformLeverOFF.localPosition, posLeverON, speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        transformLeverOFF.localPosition = Vector3.MoveTowards(transformLeverOFF.localPosition, posLeverOFF, speed * Time.deltaTime);
    }
}
