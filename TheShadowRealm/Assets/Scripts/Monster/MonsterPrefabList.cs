using System;
using System.Collections.Generic;
using Monster;
using UnityEngine;

namespace Monster {
    public class MonsterPrefabList: MonoBehaviour {
        [SerializeField] public GameObject goblin_prefab;
        [SerializeField] public GameObject crow_prefab;
        [SerializeField] public GameObject skeleton_archer_prefab;
        [SerializeField] public GameObject spider_prefab;
        [SerializeField] public GameObject kobold_prefab;
    }
    public enum MonsterType {
        Goblin,
        Crow,
        Skeleton_Archer,
        Spider,
        Kobold,
    }
}

// Shopping guide 
// class ShopValues {
//     private List<MonsterType> one_value = new List<MonsterType>() {MonsterType.Crow, MonsterType.Goblin};
// }