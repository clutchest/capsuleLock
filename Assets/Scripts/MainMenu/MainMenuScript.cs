using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject mainMenuLevel;
    [SerializeField] private GameObject seasonPicker;
    [SerializeField] private GameObject seasonBackButton;
    [SerializeField] private AudioSource buttonClick;

    [SerializeField] private GameObject levelPicker;

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Transform volumeCube;
    [SerializeField] private Vector3 minimumVolumeCubePosition;
    [SerializeField] private Vector3 maximumVolumeCubePosition;

    private AudioSource mainMenuMusic;

    private void Start()
    {
        mainMenuMusic = GetComponent<AudioSource>();
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void MainMenuButtonClick(string button)
    {
        if (button == "Play")
        {
            mainMenuPanel.SetActive(false);
            mainMenuLevel.SetActive(false);

            seasonBackButton.SetActive(true);
            seasonPicker.SetActive(true);
        }
        else if (button == "Exit")
        {
            Application.Quit();
        }
        else if (button == "Back")
        {
            mainMenuPanel.SetActive(true);
            mainMenuLevel.SetActive(true);

            seasonBackButton.SetActive(false);
            seasonPicker.SetActive(false);
        }
    }

    public void VolumeSliderOnValueChanged()
    {
        buttonClick.volume = volumeSlider.value;
        mainMenuMusic.volume = volumeSlider.value;
        volumeCube.position = Vector3.Lerp(minimumVolumeCubePosition, maximumVolumeCubePosition, volumeSlider.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.Save();
    }

    public void SeasonButtonsClick(string button)
    {
        LevelManager.currentSeason = button;

        seasonPicker.SetActive(false);
        seasonBackButton.SetActive(false);

        levelPicker.SetActive(true);
    }
}
