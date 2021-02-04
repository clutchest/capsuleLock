using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

internal static class LevelManager
{
    private static int[] levelState = new int[4] { 1, 0, 0, 0 };

    internal static string currentSeason = "Winter";
    private static int currentLevel = 1;

    private static void SaveLevelData()
    {
        if (currentSeason == "Winter" && PlayerPrefs.GetInt("Winter") < currentLevel) { levelState[0] = currentLevel; PlayerPrefs.SetInt("Winter", levelState[0]); }
        else if (currentSeason == "Spring" && PlayerPrefs.GetInt("Spring") < currentLevel) { levelState[1] = currentLevel; PlayerPrefs.SetInt("Spring", levelState[1]); }
        else if (currentSeason == "Summer" && PlayerPrefs.GetInt("Summer") < currentLevel) { levelState[2] = currentLevel; PlayerPrefs.SetInt("Summer", levelState[2]); }
        else if (currentSeason == "Autumn" && PlayerPrefs.GetInt("Autumn") < currentLevel) { levelState[3] = currentLevel; PlayerPrefs.SetInt("Autumn", levelState[3]); }
        PlayerPrefs.Save();
    }

    private static void LoadLevelData()
    {
        levelState[0] = PlayerPrefs.GetInt("Winter", 1);
        levelState[1] = PlayerPrefs.GetInt("Spring", 0);
        levelState[2] = PlayerPrefs.GetInt("Summer", 0);
        levelState[3] = PlayerPrefs.GetInt("Autumn", 0);
    }

    internal static void LoadNextLevel()
    {
        if (currentLevel == 12)
        {
            if (currentSeason == "Autumn")
            {
                //Game finished
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                return;
            }

            currentLevel = 1;
            if (currentSeason == "Winter") currentSeason = "Spring";
            else if (currentSeason == "Spring") currentSeason = "Summer";
            else if (currentSeason == "Summer") currentSeason = "Autumn";
        }
        else currentLevel++;

        SaveLevelData();

        LoadSpecificLevel(currentLevel);
    }

    internal static void LoadSpecificLevel(int level)
    {
        currentLevel = level;

        int sceneOffset = SceneOffset();

        UnityEngine.SceneManagement.SceneManager.LoadScene(level + sceneOffset);
    }

    private static int SceneOffset()
    {
        if (currentSeason == "Spring") return 12;
        else if (currentSeason == "Summer") return 24;
        else if (currentSeason == "Autumn") return 36;
        else return 0;
    }

    internal static int GetUnlockedLevels()
    {
        LoadLevelData();

        if (currentSeason == "Winter") return levelState[0];
        else if (currentSeason == "Spring") return levelState[1];
        else if (currentSeason == "Summer") return levelState[2];
        else if (currentSeason == "Autumn") return levelState[3];
        return 0;
    }
}
