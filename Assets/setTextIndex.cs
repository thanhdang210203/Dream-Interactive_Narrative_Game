using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (isNote)
        {
            button.SetActive(true);
        }
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
}
