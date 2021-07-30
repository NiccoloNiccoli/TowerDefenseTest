using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] characters = null;
    [SerializeField] private Image[] team;

    [SerializeField] const int max_team_members = 6;
    [SerializeField] private List<GameObject> selectedCharacters = null;
    private int teamMembers = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCharacters() {
        GameObject game = GameObject.FindGameObjectWithTag("GameController");
        for(int i=0; i<selectedCharacters.Count; i++) {
            game.GetComponent<GameData>().AddCharacter(selectedCharacters[i]);
        }
        
    }

    public void AddCharacter(int index) {
        if (teamMembers < max_team_members) { //XXX
            bool alreadyAdded = false;
            for(int i=0; i < max_team_members; i++) {
                if(team[i].GetComponent<AddRemoveCharacter>().index == index) {
                    alreadyAdded = true;
                }
            }
            if (!alreadyAdded) {
                team[teamMembers].sprite = characters[index].GetComponent<Hero>().iconSprite;
                team[teamMembers].GetComponent<AddRemoveCharacter>().index = index;
                teamMembers++;
                selectedCharacters.Add(characters[index]);
            }
            
            
        }
    }

    public void RemoveCharacter(int pos) {
        if(teamMembers > 0) {
            print(teamMembers);
            for(int i=pos; i<teamMembers-1; i++) {
                team[i].sprite = null;
                team[i].GetComponent<AddRemoveCharacter>().ResetIndex(team[i + 1].GetComponent<AddRemoveCharacter>().index);
                
               
            }
            selectedCharacters.RemoveAt(pos);
            team[teamMembers - 1].sprite = null;
            team[teamMembers-1].GetComponent<AddRemoveCharacter>().ResetIndex();
            

            teamMembers--;

        }
        
    }

    public GameObject GetCharacter(int index) {
        return characters[index];
    }

    public int getTeamMembers() {
        return teamMembers;
    }

    public int GetMaxTeamMembers() {
        return max_team_members;
    }
}
