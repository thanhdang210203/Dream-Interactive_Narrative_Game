using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setTextIndex : MonoBehaviour
{
    public int index;
    public GameObject textWindow;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
         noteManage.instance.noteText = text;
    }

    public void click()
    {
        textWindow.SetActive(true);
        noteManage.instance.simnpleNoteOpen(index);
    }
}
