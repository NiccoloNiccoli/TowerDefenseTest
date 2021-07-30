using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public void OnClick() {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);

    }
}
