using System.Collections;
using UnityEngine;

public class PlayerControllerMobile : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Rigidbody rb;

    private bool active = false;

    private Material playerMaterial;

    private void Start()
    {
        UIController.PlatformStateEvent += PlayerEnable;
        playerMaterial = GetComponentInChildren<Renderer>().material;
    }

    private void PlayerEnable(bool state)
    {
        rb.isKinematic = state;
        if (!state) StartCoroutine(SelectedMaterialChange());
    }

    private void OnMouseDown()
    {
        active = true;
    }

    private void OnMouseUp()
    {
        active = false;
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, 1000f, layerMask);

            rb.velocity = hit.point - transform.position;
        }
    }

    private IEnumerator SelectedMaterialChange()
    {
        float counter = 0f;

        while (true)
        {
            counter += Time.deltaTime * 5;
            counter = Mathf.Clamp(counter, 0, 1);

            playerMaterial.SetColor("_Color", Color.Lerp(Color.white, new Color(0.7f, 0.7f, 0.7f), counter));
            if (counter == 1) break;
            yield return null;
        }

        while (true)
        {
            counter -= Time.deltaTime * 3;
            counter = Mathf.Clamp(counter, 0, 0.4f);

            playerMaterial.SetColor("_Color", Color.Lerp(Color.white, new Color(0.7f, 0.7f, 0.7f), counter));
            if (counter == 0) break;
            yield return null;
        }
    }

    private void OnDestroy()
    {
        UIController.PlatformStateEvent -= PlayerEnable;
    }
}
