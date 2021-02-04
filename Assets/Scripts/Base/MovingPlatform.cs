using System.Collections;
using UnityEngine;

public abstract class MovingPlatform : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;

    [SerializeField] protected LayerMask layerMask;

    [SerializeField] protected float speed = 200f;

    //True = Vertical, False = Horizontal
    protected delegate void ActivatorEventHandler(bool platform, bool state);
    protected static event ActivatorEventHandler ActivatorEvent;

    protected bool isEnabled = true;

    protected Material platformMaterial;

    protected Color startColor;
    protected Color selectedColor = new Color(1f, 1f, 1f);


    [SerializeField] protected bool isVertical = false;
    [SerializeField] protected Seasons season;

    protected void Start()
    {
        SeasonColorChange();
        UIController.PlatformStateEvent += PlatformEnable;
        ActivatorEvent += Activate;
        platformMaterial = GetComponentInChildren<Renderer>().material;
    }

    protected void InvokeActivatorEvent(bool platform,  bool state)
    {
        if (isEnabled) ActivatorEvent?.Invoke(platform, state);
    }

    protected void PlatformEnable(bool state)
    {
        isEnabled = state;
        rb.isKinematic = !state;
        rb.velocity = new Vector3(0, 0, 0);
        if (state) StartCoroutine(SelectedMaterialChange());
    }

    protected virtual void Activate(bool platform, bool state) 
    {
        
    }

    protected IEnumerator SelectedMaterialChange()
    {
        float counter = 0f;

        while (true)
        {
            counter += Time.deltaTime * 5;
            counter = Mathf.Clamp(counter, 0, 1);

            platformMaterial.SetColor("_Color", Color.Lerp(startColor, selectedColor, counter));
            if (counter == 1) break;
            yield return null;
        }

        while (true)
        {
            counter -= Time.deltaTime * 3;
            counter = Mathf.Clamp(counter, 0, 1);

            platformMaterial.SetColor("_Color", Color.Lerp(startColor, selectedColor, counter));
            if (counter == 0) break;
            yield return null;
        }
    }

    protected void OnDestroy()
    {
        UIController.PlatformStateEvent -= PlatformEnable;
        ActivatorEvent -= Activate;
    }

    protected void SeasonColorChange()
    {
        if (isVertical)
        {
            if (season == Seasons.Spring)
            {
                ColorUtility.TryParseHtmlString("#D32626", out startColor);
            }
            else if (season == Seasons.Summer)
            {
                ColorUtility.TryParseHtmlString("#F8961E", out startColor);
            }
            else if (season == Seasons.Autumn)
            {
                ColorUtility.TryParseHtmlString("#7D0000", out startColor);
            }
            else if (season == Seasons.Winter)
            {
                ColorUtility.TryParseHtmlString("#0069FF", out startColor);
            }
        }
        else
        {
            if (season == Seasons.Spring)
            {
                ColorUtility.TryParseHtmlString("#CA5792", out startColor);
            }
            else if (season == Seasons.Summer)
            {
                ColorUtility.TryParseHtmlString("#FFBE0B", out startColor);
            }
            else if (season == Seasons.Autumn)
            {
                ColorUtility.TryParseHtmlString("#A34A28", out startColor);
            }
            else if (season == Seasons.Winter)
            {
                ColorUtility.TryParseHtmlString("#74B9FF", out startColor);
            }
        }
    }

    protected enum Seasons
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
}
