using UnityEngine;

public class HorizontalMovingPlatformMobile : MovingPlatform
{
    private bool active = false;

    private void OnMouseDown()
    {
        InvokeActivatorEvent(false, true);
    }

    private void OnMouseUp()
    {
        InvokeActivatorEvent(false, false);
    }

    protected override void Activate(bool platform, bool state)
    {
        if (!platform) 
        { 
            active = state; 
            if (state) rb.isKinematic = false; 
        }
    }

    private void FixedUpdate()
    {
        if (active && isEnabled)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, 1000f, layerMask);

            Vector3 direction = hit.point - transform.position;
            direction.Normalize();

            float angle = Vector3.Angle(transform.forward, direction);

            float distance = Vector3.Distance(hit.point, transform.position);

            float cosine = Mathf.Cos(angle * Mathf.Deg2Rad);

            Vector3 currentVelocity = transform.forward * (cosine * distance);
            currentVelocity.x = 0;

            rb.velocity = currentVelocity;
        }

        if (enabled && !active && rb.velocity == new Vector3(0, 0, 0))
        {
            rb.isKinematic = true;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
