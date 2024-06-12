using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public GameObject loadingScreen;
    public ProgressBar bar;
    public TextMeshProUGUI progressText;

    private void Awake()
    {
        instance = this;
        
        SceneManager.LoadSceneAsync((int)SceneEnum.Menu, LoadSceneMode.Additive);
    }

    List<AsyncOperation> sceneLoading = new List<AsyncOperation>();
    
    public void LoadGame()
    { 
        loadingScreen.SetActive(true);
        sceneLoading.Add(SceneManager.UnloadSceneAsync((int)SceneEnum.Menu));
        sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneEnum.UI, LoadSceneMode.Additive)); 
        sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneEnum.Game, LoadSceneMode.Additive));
        sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneEnum.Minigame, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress());
    }
    public bool IsSceneLoaded(SceneEnum scene)
    {
        return SceneManager.GetSceneByBuildIndex((int)scene).isLoaded;
    }
    
    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        for(int i = 0; i < sceneLoading.Count; i++)
        {
            while(!sceneLoading[i].isDone)
            {
                totalSceneProgress = 0;
                
                foreach(AsyncOperation operation in sceneLoading)
                {
                    totalSceneProgress += operation.progress;
                }
                
                totalSceneProgress = (totalSceneProgress / sceneLoading.Count) * 100f;
                
                bar.current = Mathf.RoundToInt(totalSceneProgress);
                
                progressText.text = "Loading... " + bar.current + "%";
                
                yield return null;
            }
        }
        
        loadingScreen.SetActive(false);
    }
}