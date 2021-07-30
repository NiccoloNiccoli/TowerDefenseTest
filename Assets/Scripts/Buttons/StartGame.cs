using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField] private GameObject nextScene;
    [SerializeField] private GameObject thisScene;
    [SerializeField] private GameObject gameLevel = null;

    public void OnClick() {
        if (thisScene.GetComponent<CharacterSelection>().getTeamMembers() == thisScene.GetComponent<CharacterSelection>().GetMaxTeamMembers()) {
            nextScene.SetActive(true);
            gameLevel.SetActive(true);
            try {
                thisScene.GetComponent<CharacterSelection>().LoadCharacters();
            }
            finally {
                thisScene.SetActive(false);
            }
            
        }
        else {
            Debug.LogError("Devi avere " + thisScene.GetComponent<CharacterSelection>().GetMaxTeamMembers() + " eroi in squadra");
        }

    }
}
