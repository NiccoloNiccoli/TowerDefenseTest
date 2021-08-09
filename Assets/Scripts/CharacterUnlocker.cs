using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharacterUnlocker : MonoBehaviour
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
            if (res[i].CompareTag("ARC"))
            {
                if (res[i].GetComponent<AddRemoveCharacter>().IsRoster)
                {
                    res[i].GetComponent<Button>().interactable = true;
                    res[i].GetComponent<AddRemoveCharacter>().enabled = false;
                    res[i].GetComponent<AddRemoveCharacter>().enabled = true;
                }
                else
                {
                    res[i].GetComponent<AddRemoveCharacter>().index = -1;
                }
                
            }
              
        }

    }
}
