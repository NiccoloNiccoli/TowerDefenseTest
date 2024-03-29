using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddRemoveCharacter : MonoBehaviour
{
    public int index;
    [SerializeField] private int position;
    [SerializeField] private GameObject charSel;
    [SerializeField] private bool isRoster = true;
    private Animator anim;
    private bool needAnUpdate = false;

    public bool IsRoster { get => isRoster; set => isRoster = value; }

    private void OnEnable() {
        anim = GetComponent<Animator>();
        var colors = GetComponent<Button>().colors;
        colors.disabledColor = Color.black;
        GetComponent<Button>().colors = colors;
        if (isRoster) {
            GetComponent<Image>().sprite = charSel.GetComponent<CharacterSelection>().GetCharacter(index).GetComponent<Hero>().iconSprite;
            anim.SetInteger("index", index);
            if (!GameObject.FindGameObjectWithTag("CharacterUnlocker").GetComponent<CharacterUnlocker>().Unlocked[index])
            {
                GetComponent<Button>().interactable = false;
            }
        }
        
    }

    private void Update() {
        if((index!=-1 && anim.GetInteger("index") != index)||needAnUpdate) {
            anim.SetInteger("index", index);
            needAnUpdate = false;
        }
    }
    public void Add() {
        charSel.GetComponent<CharacterSelection>().AddCharacter(index);
    }
    public void Remove() {
        charSel.GetComponent<CharacterSelection>().RemoveCharacter(position);
        print("remove " + position + " character");
    }
    public void ResetIndex(int i = -1) {//clean
        anim.SetInteger("index", -1);
        print("i"+i);
        index = -1;
        if (i != -1) {
            anim.SetInteger("index", i);
            index = i;
        }   
    }


}
