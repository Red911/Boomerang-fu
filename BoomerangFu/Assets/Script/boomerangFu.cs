using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour 
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultvolume = 1.0f;

/*
    [Header ( "Gameplay Settings")]
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenslider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllersen = 4;
*/

    [Header ("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    [Header ("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

/*
    [Header("Levels To Load")]
    public string _newGameLevel;
    public string _levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;
*/

    // public void NewGameDialogYes()
    // {
    //     SceneManager.LoadScene(_newGameLevel);
    // }

    /*

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            _levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }

        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    */

    public void ExitButton()
    {
        Application.Quit();
    }
    //
    // public void SetVolume()
    // {
    //     AudioListener.volume = volume;
    //     volumeTextvalue.text = volume.ToString("0.0");
    // }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    /*

    public void SetControllerSen(float sensitivity)
    {
        mainControllersen = Mathf.RoundToInt(sensitivity);
        controllerSenTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt('masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt('masterInvertY", 0);
        }
        PlayerPrefs.SetFloat("masterSen",  mainControllerSen);
        StartCoroutine(ConfirmationBox());
    }

    */

    // public void ResetButton(string MenuType)
    // {
    //     if (MenuType == "Audio")
    //     {
    //         AudioListener.volume = defaultvolume;
    //         volumeslider.value = defaultVolume;
    //         volumeTextValue.text = defaultVolume.ToString("0.0"); 
    //         VolumeApply();
    //     }
    // }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true); //activer la fenetre de confirmation?
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false); //desactiver la fenetre de confirmation?
    }
}
