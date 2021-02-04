using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool platformState = true;

    internal delegate void PlatformStateEventHandler(bool state);
    internal static event PlatformStateEventHandler PlatformStateEvent;

    private AudioSource audioSource;

    private void Start()
    {
        PlatformStateEvent?.Invoke(platformState);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void SwitchButtonClick()
    {
        platformState = !platformState;
        PlatformStateEvent?.Invoke(platformState);
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchButtonClick();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf) UIButtonClick("Pause");
            else UIButtonClick("MainMenu");
        }
    }

    public void UIButtonClick(string button)
    {
        if (button == "Pause")
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (button == "Restart")
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        else if (button == "Resume")
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (button == "MainMenu")
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
