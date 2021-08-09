using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class LevelSelection : MonoBehaviour
{
    private int currentLevelIndex = -1;
    [SerializeField] private Tilemap [] tileset;
    [SerializeField] private GameObject[] campfire;
    [SerializeField] private GameObject[] backgrounds;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject[] tokens;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject levelUnlocker;

    private void OnEnable()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            if (levelUnlocker.GetComponent<LevelUnlocker>().Unlocked[i])
            {
                buttons[i].GetComponent<Button>().interactable = true;
            }
            else
            {

                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
       
    }
    public void OnLevelClick(int i)
    {
        currentLevelIndex = i;
    }
    public void OnDoneClick()
    {
        if (currentLevelIndex != -1)
        {
            for (int i = 0; i < tileset.Length; i++)
            {
                if (i == (int)(currentLevelIndex / 3))
                {
                    tileset[i].gameObject.SetActive(true);
                    grid.GetComponent<GridController>().InteractiveMap = tileset[i];
                }
                else
                {
                    tileset[i].gameObject.SetActive(false);
                }
            }
            if (currentLevelIndex == 9)
            {
                campfire[1].SetActive(true);
                campfire[0].SetActive(false);
            }
            else
            {
                campfire[0].SetActive(true);
                campfire[1].SetActive(false);
            }
            for (int j = 0; j < backgrounds.Length; j++)
            {
                if (j == (int)(currentLevelIndex / 3))
                {
                    backgrounds[j].SetActive(true);
                }
                else
                {
                    backgrounds[j].SetActive(false);
                }
            }
            game.GetComponent<GameData>().Lvl = tokens[currentLevelIndex];
        }
       
    }
}
