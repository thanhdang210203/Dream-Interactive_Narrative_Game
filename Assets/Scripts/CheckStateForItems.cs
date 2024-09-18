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
    public GameObject[] itemsLevel4;
    public GameObject[] itemsLevel5;
    public Transform[] itemLevel1Positions;
    public Transform[] itemLevel2Positions;
    public Transform[] itemLevel3Positions;
    public Transform[] itemLevel4Positions;
    public Transform[] itemLevel5Positions;
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.currentGameState)
        {
            case gameStates.level1:
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
            case gameStates.level2:
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
            case gameStates.level3:
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
            case gameStates.level4:
                for (int i = 0; i < itemsLevel4.Length; i++)
                {
                    if (itemsLevel4[i].transform.position == itemLevel4Positions[i].position)
                    {
                        Debug.Log("Item " + itemsLevel4[i].name + " is in the correct position");
                    }
                    else
                    {
                        Debug.Log("Item " + itemsLevel4[i].name + " is not in the correct position");
                    }
                }
                break;
            case gameStates.level5:
                for (int i = 0; i < itemsLevel5.Length; i++)
                {
                    if (itemsLevel5[i].transform.position == itemLevel5Positions[i].position)
                    {
                        Debug.Log("Item " + itemsLevel5[i].name + " is in the correct position");
                    }
                    else
                    {
                        Debug.Log("Item " + itemsLevel5[i].name + " is not in the correct position");
                    }
                }
                break;
        }
    }
}
