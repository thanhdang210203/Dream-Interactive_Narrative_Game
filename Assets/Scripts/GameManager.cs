using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum gameStates
{
    level1,
    level2,
    level3,
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public gameStates currentGameState;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentGameState = gameStates.level1;
    }
}
