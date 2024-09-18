using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManage : MonoBehaviour
{
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Denial":
                GameManager.instance.currentGameState = gameStates.level1;
                Debug.Log("Denial");
                break;
            case "Anger":
                GameManager.instance.currentGameState = gameStates.level2;
                Debug.Log("Anger");
                break;
            case "Bargaining":
                GameManager.instance.currentGameState = gameStates.level3;
                Debug.Log("Baragaining");
                break;
            case "Depression":
                GameManager.instance.currentGameState = gameStates.level4;
                Debug.Log("Depression");
                break;
            case "Acceptance":
                GameManager.instance.currentGameState = gameStates.level5;
                Debug.Log("Acceptance");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
