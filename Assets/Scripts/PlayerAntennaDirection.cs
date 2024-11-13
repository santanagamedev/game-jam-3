using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAntennaDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;

        angle = Mathf.Clamp(angle, -75f, 75f);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
