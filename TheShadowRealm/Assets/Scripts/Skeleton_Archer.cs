using System;
using DefaultNamespace;
using UnityEngine;

namespace Monster
{
    public class Skeleton_Archer : MonoBehaviour, IMonster
    {
        private int value = 1;
        private int attack = 1;
        private int health = 1;
        private int movement = 1;
        private int range = 2;
        private Ability ability;
        private int x_position = Int32.MaxValue;
        private int y_position = Int32.MaxValue;
        private IMonster Target;
        private bool inRange = false;
        private bool isEnemy = false;
        private string stringType = "skeleton archer";

        public int GetValue() => value;
        public int GetAttack() => attack;
        public int GetMovement() => movement;
        public int GetRange() => range;
        public int GetHealth() => health;
        public string GetStringType() => stringType.ToLower();

        public Tuple<int, int> GetPosition() => new Tuple<int, int>(x_position, y_position);
        public int GetX() => x_position;
        public int GetY() => y_position;

        public IMonster GetTarget() => Target;

        public bool GetInRange() => inRange;
        public void SetInRange(bool value)
        {
            inRange = value;
        }

        public bool GetIsEnemy() => isEnemy;
        public void SetIsEnemy(bool value)
        {
            isEnemy = value;
        }

        // Actions
        public void Attack()
        {

        }

        public void Move()
        {

        }

        public void Ability()
        {

        }

        public void Die()
        {

        }
    }
}
