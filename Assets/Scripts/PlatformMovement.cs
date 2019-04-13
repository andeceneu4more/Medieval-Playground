using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transformLeverOFF.localPosition = Vector3.MoveTowards(transformLeverOFF.localPosition, nextPos, speed * Time.deltaTime);
        if (Vector3.Distance(transformLeverOFF.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nextPos = nextPos != posLeverOFF ? posLeverOFF : posLeverON;
    }
}
