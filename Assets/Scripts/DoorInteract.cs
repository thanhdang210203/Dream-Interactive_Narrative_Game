using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class DoorInteract : MonoBehaviour
{
    public InputAction interactKey;
    public bool isInteractable;
    // Start is called before the first frame update
    void Start()
    {
        isInteractable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactKey.triggered && isInteractable)
        {
            OpenDoor();
        }
    }
    private void OnEnable()
    {
        interactKey.Enable();
    }

    private void OnDisable()
    {
        interactKey.Disable();
    }
    
    public void OpenDoor()
    {
        AudioManager.instance.PlaySoundEffect(8);
        GameManager.instance.currentGameState = gameStates.level3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySoundEffect(0);
            Debug.Log("Player entered the " + this.name+"'s interaction area");
            isInteractable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The player has exited the item's interaction area
            Debug.Log("Player exited the " + this.name+"'s interaction area");
            isInteractable = false;
        }
    }
}
