using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlaformController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject platform;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float speed;
    private Vector3 movementDirection;
    void Start()
    {
        movementDirection = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveElevator();
    }

    void MoveElevator()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, movementDirection, speed * Time.deltaTime);

        
        if (platform.transform.position == endPoint.position)
        {
            movementDirection = startPoint.position;
        }if(platform.transform.position == startPoint.position)
        {
            movementDirection = endPoint.position;
        }
        
        //movementDirection = platform.transform.position == endPoint.position ? startPoint.position : endPoint.position;
    }
   
}
