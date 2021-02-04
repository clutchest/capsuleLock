using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScene : MonoBehaviour
{
    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
