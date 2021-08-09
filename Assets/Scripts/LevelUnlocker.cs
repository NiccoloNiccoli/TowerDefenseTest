using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] bool[] unlocked;

    public bool[] Unlocked { get => unlocked; set => unlocked = value; }

    // Start is called before the first frame update
    public void Unlock(int index)
    {
        unlocked[index] = true;
        var res = Resources
    .FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < res.Length; i++)
        {
            if (res[i].CompareTag("LevelButton"))
            {
                    res[i].GetComponent<Button>().interactable = true;
                }
            }
        }
    }
