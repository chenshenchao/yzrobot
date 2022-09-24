using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallUIBehaviour : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject settingPanel;
    public GameObject quitDialog;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickSettingButton()
    {
        loginPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void OnClickSettingBackButton()
    {
        loginPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void OnClickSettingSaveButton()
    {

    }

    public void OnClickQuitButton()
    {
        quitDialog.SetActive(true);
    }

    public void OnClickQuitYesButton()
    {
        Application.Quit();
    }

    public void OnClickQuitNoButton()
    {
        quitDialog.SetActive(false);
    }
}
