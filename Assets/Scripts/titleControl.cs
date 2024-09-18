using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class titleControl : MonoBehaviour
{
    public GameObject text;
    public float timeToPop;
    public float timeToHide;
    public bool isTutorial;
    public GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(titlePop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator titlePop()
    {
        AudioManager.instance.PlayBackgroundMusic(0);
        yield return new WaitForSeconds(timeToPop);
        text.SetActive(true);
        AudioManager.instance.PlayBackgroundMusic(1);
        yield return new WaitForSeconds(timeToHide);
        text.SetActive(false);
        if(SceneManager.GetActiveScene().name == "Denial" && isTutorial)
        {
            openTutorial();
        }
    }
    public void openTutorial()
    {
        tutorial.SetActive(true);
        AudioManager.instance.PlaySoundEffect(2);
        tutorial.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
    }
    public void closeTutorial()
    {
        tutorial.SetActive(false);
    }
}
