using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PCController : MonoBehaviour
{
    public static PCController instance;
    public int index;
    
    public GameObject docWindow;

    public TextMeshProUGUI text;

    public GameObject trashFile;

    public GameObject fileWindow;
    
    public TextData textData;

    public GameObject PCCanvas;
    // Start is called before the first frame update
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openPC()
    {
        AudioManager.instance.PlaySoundEffect(4);
        PCCanvas.SetActive(true);
    }
    
    public void OpenDocWindow()
    {
        AudioManager.instance.PlaySoundEffect(6);
        docWindow.SetActive(true);
    }
    
    public void CloseDocWindow()
    {
        AudioManager.instance.PlaySoundEffect(6);
        docWindow.SetActive(false);
    }
    
    public void OpenFileWindow()
    {
        AudioManager.instance.PlaySoundEffect(6);
        fileWindow.SetActive(true);
    }
    
    public void CloseFileWindow()
    {
        AudioManager.instance.PlaySoundEffect(6);
        fileWindow.SetActive(false);
        CloseDocWindow();
    }
    
    public void OpenTrashFile()
    {
        AudioManager.instance.PlaySoundEffect(6);
        trashFile.SetActive(true);
    }
    
    public void CloseTrashFile()
    {
        AudioManager.instance.PlaySoundEffect(6);
        trashFile.SetActive(false);
        CloseDocWindow();
    }
    
    public void ReadNote()
    {
        OpenDocWindow();
        noteManage.instance.simnpleNoteOpen(index);
    }
    
    public void powerOffPC()
    {
        AudioManager.instance.PlaySoundEffect(5);
       PCCanvas.SetActive(false);
    }
}
