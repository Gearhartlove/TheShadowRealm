using System;
using System.Collections.Generic;
using Monster;
using UnityEngine;

namespace Monster
{
    public class MonsterValueList : MonoBehaviour
    {
        private List<MonsterType> one_value = new List<MonsterType>() { MonsterType.Crow, MonsterType.Goblin, MonsterType.Skeleton_Archer, MonsterType.Spider };
        private List<MonsterType> two_value = new List<MonsterType>() { };
        private List<MonsterType> three_value = new List<MonsterType>() { };
        private List<MonsterType> four_value = new List<MonsterType>() { };

        public List<MonsterType> GetValueOneMonsters()
        {
            return one_value;
        }

        public List<MonsterType> GetValueTwoMonsters()
        {
            return two_value;
        }

        public List<MonsterType> GetValueThreeMonsters()
        {
            return three_value;
        }

        public List<MonsterType> GetValueFourMonsters()
        {
            return four_value;
        }
    }
}