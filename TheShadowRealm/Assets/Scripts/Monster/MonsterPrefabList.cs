using System;
using System.Collections.Generic;
using Monster;
using UnityEngine;

namespace Monster {
    public class MonsterPrefabList: MonoBehaviour {
        [SerializeField] public GameObject goblin_prefab;
    }
    public enum MonsterType {
        Goblin,
        Crow,
    }
}

// Shopping guide 
// class ShopValues {
//     private List<MonsterType> one_value = new List<MonsterType>() {MonsterType.Crow, MonsterType.Goblin};
// }