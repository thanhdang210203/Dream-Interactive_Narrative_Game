using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleControl : MonoBehaviour
{
    public GameObject text;
    public float timeToPop;
    public float timeToHide;
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
    }
}
