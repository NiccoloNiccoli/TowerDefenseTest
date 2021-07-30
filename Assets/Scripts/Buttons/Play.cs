using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject nextScene;
    [SerializeField] private GameObject thisScene;
    
    public void OnClick() {
        nextScene.SetActive(true);
        thisScene.SetActive(false);
    }
}
