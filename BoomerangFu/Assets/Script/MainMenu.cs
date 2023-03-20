using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject MainMenuUI;
    public GameObject StartButton;
    
    [Header("Map Selection")]
    public GameObject MapSelectionMenu;
    public GameObject Map1Button;
    public List<GameObject> levels = new List<GameObject>();

    [Header("Player Selection")]
    public GameObject PlayerSelection;
    
    void Start()
    {
        
    }
    
    public void MainMenuButton()
    {
        MainMenuUI.SetActive(true);
        StartCoroutine(SelectionMenu(StartButton));
    }
    
    public void MapSelectionButton()
    {
        MapSelectionMenu.SetActive(true);
        CloseMenu(MainMenuUI);
        StartCoroutine(SelectionMenu(Map1Button));
    }
    
    public void PlayerSelectionButton()
    {
        PlayerSelection.SetActive(true);
        CloseMenu(MainMenuUI);
    }

    public void SetLevel(string LevelName)
    {
        GameManager.Instance.levelName = LevelName;
    }
    
    public void Quit()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        var uiModule = (InputSystemUIInputModule)EventSystem.current.currentInputModule;
        InputAction cancel = uiModule.cancel.action;
        
        
        if (MapSelectionMenu.activeInHierarchy)
        {
            if (cancel.WasPressedThisFrame())
            {
                MainMenuButton();
                CloseMenu(MapSelectionMenu);
                
            }
        }
        
    }
    
    private void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    
    private IEnumerator SelectionMenu(GameObject SelectButton)
    {
        yield return new WaitForSeconds(0.1f);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(SelectButton, new BaseEventData(eventSystem));
    }
}
