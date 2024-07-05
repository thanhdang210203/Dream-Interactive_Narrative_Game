using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public GameObject popUp;


    private void Start()
    {
        popUp.SetActive(false);
    }
    
    public void pressStart()
    {
        popUp.SetActive(true);
        popUp.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
    }
    
    public void pressExit()
    {
        Application.Quit();
    }

    public void confirm()
    {
        SceneManager.LoadScene("Environment");
    }
}
