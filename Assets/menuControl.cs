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
        AudioManager.instance.PlaySoundEffect(2);
        popUp.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
    }
    
    public void pressExit()
    {
        AudioManager.instance.PlaySoundEffect(1);
        Application.Quit();
    }

    public void confirm()
    {
        AudioManager.instance.PlaySoundEffect(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
