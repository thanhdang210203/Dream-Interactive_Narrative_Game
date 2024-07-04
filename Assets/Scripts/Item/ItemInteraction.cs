using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    public GameObject interactionUI;
    public Camera mainCamera;
    public Canvas canvas;
    
    [SerializeField] private bool isInteractable;
    private void Start()
    {
        mainCamera = Camera.main;
        canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = mainCamera;
        isInteractable = false;
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is on the player's layer
        if (other.CompareTag("Player"))
        {
            popUpUI();
            Debug.Log("Player entered the " + this.name+"'s interaction area");
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The player has exited the item's interaction area
            closeUI();
            Debug.Log("Player exited the " + this.name+"'s interaction area");
            isInteractable = false;
        }
    }

    void popUpUI()
    {
        interactionUI.transform.DOScale(1, 0.5f).SetEase(Ease.Linear);
    }
    
    void closeUI()
    {
        interactionUI.transform.DOScale(0, 0.5f).SetEase(Ease.Linear);
    }
}