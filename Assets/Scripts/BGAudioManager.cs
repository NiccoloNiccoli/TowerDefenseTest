using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private GameObject[] mainMenu;
    private AudioSource audio;
    private bool beforeIMM = false;
    private bool inMainMenu = false;
    void Start()
    {
        audio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        inMainMenu = false;
        for(int i = 0; i < mainMenu.Length; i++) {
            if (mainMenu[i].activeInHierarchy) {
                inMainMenu = true;
            }
        }
        if(inMainMenu && !beforeIMM) {
            audio.clip = mainMenuMusic;
            audio.Play();
            beforeIMM = true;
        }
        if (!inMainMenu && beforeIMM) {
            audio.Stop();
            audio.clip = gameMusic;
            audio.Play();
            beforeIMM = false;
        }
    }
}
