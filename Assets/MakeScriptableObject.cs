using UnityEngine;

[CreateAssetMenu(fileName = "NewGameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
        [System.Serializable]
        public class Item
        {
            public GameObject gameObject;
            public int value;
        }

        [System.Serializable]
        public class StageData
        {
            public GameStageEnum gameStage;
            public Item[] items;
        }

        public StageData[] stages;
}