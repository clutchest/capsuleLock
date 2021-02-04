using UnityEngine;

public class PlayerControllerComputer : MonoBehaviour
{
    [SerializeField] private float speed = 1.2f;

    [SerializeField] private Rigidbody rb;

    private Vector3 movingDirection;

    private bool active = false;

    private void Start()
    {
        UIController.PlatformStateEvent += PlayerEnable;
    }

    private void PlayerEnable(bool state)
    {
        rb.isKinematic = state;
        active = !state;
    }

    private void Update()
    {
        if (active == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))movingDirection += transform.forward;
            else movingDirection = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.DownArrow)) movingDirection += -transform.forward;
            if (Input.GetKey(KeyCode.LeftArrow)) movingDirection += -transform.right;
            if (Input.GetKey(KeyCode.RightArrow)) movingDirection += transform.right;

            movingDirection.Normalize();

            movingDirection *= speed;

            rb.velocity = movingDirection;
        }
    }

    private void OnDestroy()
    {
        UIController.PlatformStateEvent -= PlayerEnable;
    }
}
