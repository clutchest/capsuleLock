using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour
{
    public GameObject ENTRYpanel; //prvi i glavni panel
    public GameObject SEASONpanel; //panel za biranje godisnjeg doba
    public GameObject LEVELSpanel;  //panel na options buttonu

    
    public Slider volume; //slider glasnoce pozadinske glazbe

    AudioSource audioS;

   

    private void Awake()
    {
        LEVELSpanel.SetActive(false);
        ENTRYpanel.SetActive(true);
        SEASONpanel.SetActive(false);
    }

    public void Start()
    {
        audioS = GetComponent<AudioSource>();
        volume.value = PlayerPrefs.GetFloat("volume"); //povlaci vrijednost volume 
    }
    public void OnPlay()
    {
        //otvaranje panela biranja godisnjih doba (SEASONpanel)
        ENTRYpanel.SetActive(false);
        SEASONpanel.SetActive(true);
    }

    //ON SEASONS
    //jesen
    public void OnAutumn()
    {
        //biranje godisnjih doba - JESEN
        SEASONpanel.SetActive(false);
        LEVELSpanel.SetActive(true);
    }
    //proljece
    public void OnSpring()
    {

    }
    //ljeto
    public void OnSummer()
    {

    }
    //zima
    public void OnWinter()
    {

    }


    //ON BACK BUTTONS
    public void OnLevelsBack()
    {
        //vraca na biranje godisnjih doba
        SEASONpanel.SetActive(true);
        LEVELSpanel.SetActive(false);
    }
    public void OnSeasonBack()
    {
        //vraca na pocetni izbornik igre
        SEASONpanel.SetActive(false);
        ENTRYpanel.SetActive(true);
    }

    //ON VOLUME CHANGE
    public void OnVolumeChangeSlider()
    {
        //namjestanje glasnoce zvuka
        audioS.volume = volume.value; 
        PlayerPrefs.SetFloat("volume", audioS.volume); //save volume vrijednosti
    }

    //ON LEVEL CLICK
    public void LevelButtonClick(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
