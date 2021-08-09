using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField] private GameObject nextScene;
    [SerializeField] private GameObject thisScene;
    [SerializeField] private GameObject gameLevel = null;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject[] buttons;

    public void OnClick() {
        game.GetComponent<GameData>().Init1();
        if (thisScene.GetComponent<CharacterSelection>().getTeamMembers() == thisScene.GetComponent<CharacterSelection>().GetMaxTeamMembers()) {
            nextScene.SetActive(true);
            gameLevel.SetActive(true);
            try {
                thisScene.GetComponent<CharacterSelection>().LoadCharacters();
            }
            finally {
                game.GetComponent<GameData>().Init2();
                for(int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].GetComponent<Buttons>().MustInit = true;
                }
                thisScene.SetActive(false);
                
            }
            
        }
        else {
            Debug.LogError("Devi avere " + thisScene.GetComponent<CharacterSelection>().GetMaxTeamMembers() + " eroi in squadra");
        }

    }
}
