using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public SaveObject so;
    [SerializeField] private GameObject characterUnlocker;
    [SerializeField] private GameObject levelUnlocker;

    void Start()
    {
        so = SaveManager.Load();

        for (int i = 0; i < so.nCharacterUnlocked; i++)
            characterUnlocker.GetComponent<CharacterUnlocker>().Unlocked[i] = true;
        for (int i = 0; i < so.nLevelUnlocked; i++)
            levelUnlocker.GetComponent<LevelUnlocker>().Unlocked[i] = true;

    }

    
    void Update()
    {
        
    }
}
