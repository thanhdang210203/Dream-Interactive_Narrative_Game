using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class setTextIndex : MonoBehaviour
{
    public int index;
    public GameObject textWindow;
    public TextMeshProUGUI text;
    public bool isNote;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        noteManage.instance.noteText = text;
    }

    public void click()
    {
        textWindow.SetActive(true);
        AudioManager.instance.PlaySoundEffect(6);
        noteManage.instance.simnpleNoteOpen(index);
    }

    public void changeTheScene()
    {
       AudioManager.instance.PlaySoundEffect(6);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       GameManager.instance.currentGameState = gameStates.level2;
    }

    public void wakeup()
    {
        textWindow.SetActive(true);
        AudioManager.instance.PlaySoundEffect(6);
        noteManage.instance.simnpleNoteOpen(index);
        button.SetActive(true);
        button.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
    }
}
