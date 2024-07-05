using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
public class ItemInteraction : MonoBehaviour
{
    public GameObject interactionUI;
    public Camera mainCamera;
    public Canvas canvas;
    public int noteIndex;
    [SerializeField] private bool isInteractable;
    public InputAction interactKey;
    
    public bool isPC;
    private void Start()
    {
        mainCamera = Camera.main;
        canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = mainCamera;
        isInteractable = false;
    }
    
    private void OnEnable()
    {
        interactKey.Enable();
    }

    private void OnDisable()
    {
        interactKey.Disable();
    }

    private void Update()
    {
        interactionUI.transform.LookAt(mainCamera.transform);
        if (isInteractable)
        {
            if(interactKey.triggered && isPC)
            {
                PCController.instance.openPC();
            }
            if (interactKey.triggered && !isPC)
            { 
                noteManage.instance.openNote(noteIndex);
                Debug.Log("Player interacted with " + this.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is on the player's layer
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySoundEffect(0);
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
        interactionUI.transform.DOScale(0.01f, 0.2f).SetEase(Ease.OutBounce);
    }
    
    void closeUI()
    {
        interactionUI.transform.DOScale(0, 0.2f).SetEase(Ease.Linear);
    }
}