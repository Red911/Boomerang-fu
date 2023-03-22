using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject MainMenuUI;

    [Header("Player Selection")]
    public PlayerInputManager PlayerSelection;
    
    public void PlayerSelectionButton()
    {
        PlayerSelection.enabled = true;
        print("bite");
        CloseMenu(MainMenuUI);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    
}
