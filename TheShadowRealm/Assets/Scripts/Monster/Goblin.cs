using System;
using DefaultNamespace;
using UnityEngine;

namespace Monster {
    public class Goblin : MonoBehaviour, IMonster {
        private int value = 1; 
        private int attack = 1; 
        private int health = 2; 
        private int movement = 1; 
        private int range = 1;
        private Ability ability;
        private int x_position = Int32.MaxValue;    
        private int y_position = Int32.MaxValue;
        private IMonster target;
        private bool inRange = false;
        private bool isEnemy = false;
        private string stringType = "goblin";

        public int GetValue() => value;
        public int GetAttack() => attack;
        public int GetMovement() => movement;
        public int GetRange() => range;
        public int GetHealth() => health;
        public string GetStringType() => stringType.ToLower();

        public Tuple<int, int> GetPosition() => new Tuple<int, int>(x_position, y_position);
        public int GetX() => x_position;
        public int GetY() => y_position;

        public void SetX(int x) {
            x_position = x;
        }

        public void SetY(int y) {
            y_position = y;
        }

        public IMonster GetTarget() => target;

        public bool GetInRange() => inRange;
        public void SetInRange(bool isRange) {
            inRange = isRange;
        }

        public bool GetIsEnemy() => isEnemy;
        public void SetIsEnemy(bool enemy) {
            isEnemy = enemy;
        }

        // Actions
        public void Attack() {
            target.DamageHealth(GetAttack());
        }

        public void DamageHealth(int attack) {
            health -= attack;
        }

        public void Move() {
        
        }

        public void Ability() {
        }

        public void Die() {
        
        }
    }
}