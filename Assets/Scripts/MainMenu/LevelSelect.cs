using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject seasonPicker;
    [SerializeField] private GameObject seasonPickerBackButton;

    [SerializeField] private Button[] levelButtons;

    private void OnEnable()
    {
        int currentUnlockedLevels = LevelManager.GetUnlockedLevels();

        for (int c = 0; c < currentUnlockedLevels; c++)
        {
            levelButtons[c].interactable = true;
        }
    }

    public void BackButtonClick()
    {
        seasonPicker.SetActive(true);
        seasonPickerBackButton.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void LevelButtonClick(int button)
    {
        LevelManager.LoadSpecificLevel(button);
    }

    private void OnDisable()
    {
        foreach (Button levelButton in levelButtons) levelButton.interactable = false;
    }
}
