using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class doorLasr : MonoBehaviour
{
    public InputAction interactKey;
        public bool isInteractable;
        public GameObject popUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        interactKey.Enable();
    }

    private void OnDisable()
    {
        interactKey.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if(interactKey.triggered && isInteractable)
        {
            StartCoroutine(accept());
        }
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
    IEnumerator accept()
        {
            popUp.SetActive(true);
            popUp.GetComponent<CanvasGroup>().DOFade(1, 3f);
            yield return new WaitForSeconds(3f);
            popUp.GetComponent<CanvasGroup>().DOFade(0, 1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    
}
