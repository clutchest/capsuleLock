using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public MoveToNextLevel mtnlScript;

    public void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1); //level select je panel u nultoj (prvoj) sceni

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if(i+1 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    public void OnLevel()
    {
        SceneManager.LoadScene(mtnlScript.nextSceneLoad);
    }

}
