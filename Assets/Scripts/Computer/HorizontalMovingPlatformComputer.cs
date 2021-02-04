using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatformComputer : MovingPlatform
{
    private void FixedUpdate()
    {
        if (isEnabled)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(new Vector3(0, 0, -1) * Time.deltaTime * speed);
            }
        }
    }
}
