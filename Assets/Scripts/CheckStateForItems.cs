using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check State For Items", menuName = "CheckStateForItems", order = 1)]
public class CheckStateForItems : ScriptableObject
{
    public GameObject[] itemsLevel1;
    public GameObject[] itemsLevel2;
    public GameObject[] itemsLevel3;
    public Transform[] itemLevel1Positions;
    public Transform[] itemLevel2Positions;
    public Transform[] itemLevel3Positions;
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManger.instance.currentGameState)
        {
            case gameState.level1:
                for (int i = 0; i < itemsLevel1.Length; i++)
                {
                    if (itemsLevel1[i].transform.position == itemLevel1Positions[i].position)
                    {
                        Debug.Log("Item " + itemsLevel1[i].name + " is in the correct position");
                    }
                    else
                    {
                        Debug.Log("Item " + itemsLevel1[i].name + " is not in the correct position");
                    }
                }

                break;
            case gameState.level2:
                for (int i = 0; i < itemsLevel2.Length; i++)
                {
                    if (itemsLevel2[i].transform.position == itemLevel2Positions[i].position)
                    {
                        Debug.Log("Item " + itemsLevel2[i].name + " is in the correct position");
                    }
                    else
                    {
                        Debug.Log("Item " + itemsLevel2[i].name + " is not in the correct position");
                    }
                }
                break;
            case gameState.level3:
                for (int i = 0; i < itemsLevel3.Length; i++)
                {
                    if (itemsLevel3[i].transform.position == itemLevel3Positions[i].position)
                    {
                        Debug.Log("Item " + itemsLevel3[i].name + " is in the correct position");
                    }
                    else
                    {
                        Debug.Log("Item " + itemsLevel3[i].name + " is not in the correct position");
                    }
                }
                break;
        }
    }
}
