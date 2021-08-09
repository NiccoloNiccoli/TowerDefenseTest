using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Play : MonoBehaviour
{
    [SerializeField] private GameObject nextScene;
    [SerializeField] private GameObject[] thisScene;
    [SerializeField] private GameObject CS;
    
    public void OnClick() {
        nextScene.SetActive(true);
        for(int i = 0; i<thisScene.Length;i++)
            thisScene[i].SetActive(false);
       
    }
    public void OnClickHome()
    {
        var res = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        for (int i = 0; i < res.Length; i++)
        {
            if(res[i].CompareTag("Hero") || res[i].CompareTag("Enemy") || res[i].CompareTag("Misc"))
                Destroy(res[i]);
        }

        var arc = Resources
   .FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < arc.Length; i++)
        {
            if (arc[i].CompareTag("ARC"))
            {
                if (!arc[i].GetComponent<AddRemoveCharacter>().IsRoster)
                {
                    arc[i].GetComponent<Image>().sprite = null;
                    arc[i].GetComponent<AddRemoveCharacter>().index = -1;
                    CS.GetComponent<CharacterSelection>().TeamMembers = 0;
                }
            }

        }
        OnClick();
        Time.timeScale = 1.0f;


    }
}
