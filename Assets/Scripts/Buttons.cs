using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject hero = null;
    private int buttonNumber;
    [SerializeField] private TextMeshProUGUI tmp_cost = null;
    [SerializeField] private GameObject grid = null;
    private Animator anim;

    private int cost;
    private bool mustInit = true;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        if (mustInit) {
            anim = GetComponent<Animator>();
            anim.SetInteger("index", hero.GetComponent<Hero>().iconAnimIndex);
            Sprite icon = GetComponent<Image>().sprite;
            icon = hero.GetComponent<Hero>().iconSprite;
            cost = hero.GetComponent<Hero>().GetCost();
            tmp_cost.SetText(cost.ToString());
            mustInit = false;
        }
    }

    public void OnClick() {
        grid.GetComponent<GridController>().selectHero(buttonNumber);
    }

    public void UpdateButtons(int money) {
        if(money >= cost) {
            GetComponent<Button>().interactable = true;
        }
        else {
            GetComponent<Button>().interactable = false;
        }
    }

    public void LoadHero(GameObject h) {
        hero = h;
    }

    public void SetButtonNumber(int i) {
        buttonNumber = i;
    }
}
