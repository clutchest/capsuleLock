using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume", 1f);
    }
}
