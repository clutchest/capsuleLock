using UnityEngine;

public class VerticalMovingPlatformMobile : MovingPlatform
{
    private bool active = false;

    protected void OnMouseDown()
    {
        InvokeActivatorEvent(true, true);
    }

    protected void OnMouseUp()
    {
        InvokeActivatorEvent(true, false);
    }

    protected override void Activate(bool platform, bool state)
    {
        if (platform) 
        { 
            active = state; 
            if (state) rb.isKinematic = false; 
        }
    }

    private void FixedUpdate()
    {
        if (active && isEnabled)
        {
            //Converts mouse position on screen to Ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //This will contain the point in 3D space where mouse is

            //Casts a ray to get the mouse position in 3D space and saves it to RaycastHit hit;
            Physics.Raycast(ray, out hit, 1000f, layerMask);

            //Get the directional Vector3 
            Vector3 direction = hit.point - transform.position;
            direction.Normalize();

            //Calculates the angle between platforms right direction and variable 'direction'
            float angle = Vector3.Angle(transform.right, direction);

            //Calulate the distance between platform and where mouse clicked
            float distance = Vector3.Distance(hit.point, transform.position);

            //Calculates cosine from angle calculated above
            float cosine = Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector3 currentVelocity = transform.right * (cosine * distance);
            currentVelocity.z = 0;

            rb.velocity = currentVelocity;
        }

        if (enabled && !active && rb.velocity == new Vector3(0, 0, 0))
        {
            rb.isKinematic = true;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
