using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameData : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI tmp_money;
    [SerializeField] private GameObject[] buttons = null;
    [SerializeField] private int money; //how much money you have at the beginning of a new game
    [SerializeField] private List<GameObject> characters;

    [SerializeField] private Image pBar_filling = null;
    private int totalEnemies;
    private int killedEnemies = 0;

    const int maxEnemiesPerLevel = 150;
    const int minEnemiesPerLevel = 30;
    private int seed;
    private void Awake() {
        
        string seedString = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString()
            + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();
        tmp_money.SetText(money.ToString());
        seed = int.Parse(seedString);
        Random.InitState(seed);

        totalEnemies = Random.Range(minEnemiesPerLevel, maxEnemiesPerLevel);
        print(totalEnemies);
    }

    void Start()
    {
        if (characters.Count == buttons.Length) {
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].GetComponent<Buttons>().LoadHero(characters[i]);
                buttons[i].GetComponent<Buttons>().SetButtonNumber(i);
            }
        }
        else {
            Debug.LogError("GameData: characters.length is not equal as buttons.length");
            //TODO error
        }
        print("seed: " + seed.ToString());
        
        UpdateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void UpdateProgressBar() {
        //sezione critica?
        killedEnemies++;
        float fillAmount = 1 / (float)totalEnemies;
        pBar_filling.fillAmount += fillAmount;
        if (killedEnemies == totalEnemies) {
            print("Hai vinto!");
            Time.timeScale = 0.0f;
            //TODO, hai vinto
        }
    }

    public void AddCharacter(GameObject character) {
        characters.Add(character);
    }
}
