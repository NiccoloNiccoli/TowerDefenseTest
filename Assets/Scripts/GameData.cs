using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameData : MonoBehaviour
{
    public SaveObject so;

    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI tmp_money;
    [SerializeField] private GameObject[] buttons = null;
    [SerializeField] private int money; //how much money you have at the beginning of a new game
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private GameObject winningScene;
    [SerializeField] private GameObject losingScene;
    [SerializeField] private GameObject grid;
    [SerializeField] private Image pBar_filling = null;
    private int totalEnemies;
    private int killedEnemies = 0;

    const int maxEnemiesPerLevel = 150;
    const int minEnemiesPerLevel = 30;

    [SerializeField] private GameObject lvl;
    private int seed;

    public GameObject Lvl { get => lvl; set => lvl = value; }
    public int Money { get => money; set => money = value; }

    private void Start() {
        tmp_money.SetText(money.ToString());
        totalEnemies = lvl.GetComponent<Level>().MaxEnemies;
        if (characters.Count == buttons.Length)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Buttons>().LoadHero(characters[i]);
                buttons[i].GetComponent<Buttons>().SetButtonNumber(i);
            }
        }
        else
        {
            Debug.LogError("GameData: characters.length is not equal as buttons.length");
            //TODO error
        }
        UpdateButtons();
    }
    public void Init1()
    {
        characters.Clear();
        characters = new List<GameObject>();
        money = 200;
        grid.GetComponent<GridController>().reset();
        pBar_filling.fillAmount = 0;
        killedEnemies = 0;
        tmp_money.SetText(money.ToString());
        totalEnemies = lvl.GetComponent<Level>().MaxEnemies;
    }
    public void Init2()
    {
        if (characters.Count == buttons.Length)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Buttons>().LoadHero(characters[i]);
                buttons[i].GetComponent<Buttons>().SetButtonNumber(i);
            }
        }
        else
        {
            Debug.LogError("GameData: characters.length is not equal as buttons.length");
            //TODO error
        }
        UpdateButtons();
        StartCoroutine(StartSpawning());
    }
    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(3f);
        lvl.GetComponent<Level>().Spawn();
    }

    public void Earn(int earning) {
        money += earning;

        //updates ui
        tmp_money.SetText(money.ToString());

        UpdateButtons();
        
    }

    private void UpdateButtons() {
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].GetComponent<Buttons>().UpdateButtons(money);
        }
    }

    public GameObject GetHero(int index) {
        return characters[index];
    }

    public void UpdateProgressBar()
    {
        killedEnemies++;
        float fillAmount = 1 / (float)totalEnemies;
        pBar_filling.fillAmount += fillAmount;
        if (killedEnemies == totalEnemies)
        {
            Time.timeScale = 0.0f;
            winningScene.SetActive(true);
            Save();
            if (!GameObject.FindGameObjectWithTag("CharacterUnlocker").GetComponent<CharacterUnlocker>().Unlocked[(6 + lvl.GetComponent<Level>().Levelnumber) < 15 ? 6 + lvl.GetComponent<Level>().Levelnumber : 14])
            {
                GameObject.FindGameObjectWithTag("CharacterUnlocker").GetComponent<CharacterUnlocker>().Unlock((6 + lvl.GetComponent<Level>().Levelnumber) < 15 ? 6 + lvl.GetComponent<Level>().Levelnumber : 14);
            }
            if (!GameObject.FindGameObjectWithTag("LevelUnlocker").GetComponent<LevelUnlocker>().Unlocked[(1 + lvl.GetComponent<Level>().Levelnumber) <= 9 ? (1 + lvl.GetComponent<Level>().Levelnumber) : 9])
            {
                GameObject.FindGameObjectWithTag("LevelUnlocker").GetComponent<LevelUnlocker>().Unlock((1 + lvl.GetComponent<Level>().Levelnumber) <= 9 ? (1 + lvl.GetComponent<Level>().Levelnumber) : 9);

            }
        }
    }
    public void Lose()
    {
        lvl.GetComponent<Level>().StopSpawning();
        Time.timeScale = 0.0f;
        losingScene.SetActive(true);
        Save();
       
    }

    public void AddCharacter(GameObject character) {
        characters.Add(character);
    }
    public void Save()
    {
        int nLevelUnlocked = 0;
        bool[] LU_U = GameObject.FindGameObjectWithTag("LevelUnlocker").GetComponent<LevelUnlocker>().Unlocked;
        for (int i = 0; i< LU_U.Length; i++)
        {
            if (LU_U[i])
                nLevelUnlocked++;
        }
        so.nLevelUnlocked = ++nLevelUnlocked;

        int nCharUnlocked = 0;
        bool[] CU_U = GameObject.FindGameObjectWithTag("CharacterUnlocker").GetComponent<CharacterUnlocker>().Unlocked;
        for (int i = 0; i < CU_U.Length; i++)
        {
            if (CU_U[i])
                nCharUnlocked++;
        }
        so.nCharacterUnlocked = ++nCharUnlocked;

        SaveManager.Save(so);
    }
}
