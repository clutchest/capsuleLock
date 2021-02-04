using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THIS DOES: U seasons panelu na pritisak godisnjeg doba otvara panel sa levelima odabranog godisnjeg doba

public class LevelsBySeason : MonoBehaviour
{
    [SerializeField]
    GameObject WINTER_Panel;
    [SerializeField]
    GameObject SPRING_Panel;
    [SerializeField]
    GameObject SUMMER_Panel;
    [SerializeField]
    GameObject AUTUMN_Panel;
    [SerializeField]
    GameObject SEASONS_Panel;

    private void Start()
    {
        WINTER_Panel.SetActive(false);
        SPRING_Panel.SetActive(false);
        SUMMER_Panel.SetActive(false);
        AUTUMN_Panel.SetActive(false);
    }

    //ZA BUTTONE
    public void OnWinter()
    {
        SEASONS_Panel.SetActive(false);
        WINTER_Panel.SetActive(true);
    }
    public void OnSpring()
    {
        SEASONS_Panel.SetActive(false);
        SPRING_Panel.SetActive(true);
    }
    public void OnSummer()
    {
        SEASONS_Panel.SetActive(false);
        SUMMER_Panel.SetActive(true);
    }
    public void OnAutumn()
    {
        SEASONS_Panel.SetActive(false);
        AUTUMN_Panel.SetActive(true);
    }

    //BACK ZA BUTTONE
    public void OnWinterBack()
    {
        WINTER_Panel.SetActive(false);
        SEASONS_Panel.SetActive(true);
    }

    public void OnSpringBack()
    {
        SPRING_Panel.SetActive(false);
        SEASONS_Panel.SetActive(true);
    }

    public void OnSummerBack()
    {
        SUMMER_Panel.SetActive(false);
        SEASONS_Panel.SetActive(true);
    }

    public void OnAutumnBack()
    {
        AUTUMN_Panel.SetActive(false);
        SEASONS_Panel.SetActive(true);
    }
}
