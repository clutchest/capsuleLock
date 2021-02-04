using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatformComputer : MovingPlatform
{
    private void FixedUpdate()
    {
        if (isEnabled)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector3(1, 0, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
            }
        }
    }
}
