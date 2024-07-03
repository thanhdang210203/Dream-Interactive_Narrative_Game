using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum gameState
{
    level1,
    level2,
    level3,
}
public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public GameObject loadingScreen;
    public ProgressBar bar;
    public TextMeshProUGUI progressText;
    public gameState currentGameState;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentGameState = gameState.level1;
    }
    
    
}