using System;

namespace Monster {
    public interface IMonster {
        
        int GetValue();
        int GetAttack();
        int GetMovement();
        int GetRange();
        int GetHealth();
        string GetStringType();
        
        Tuple<int, int> GetPosition();
        int GetX();
        int GetY();
        void SetY(int x);
        void SetX(int y);
        
        IMonster GetTarget();
        
        bool GetInRange();
        void SetInRange(bool value);

        bool GetIsEnemy();
        void SetIsEnemy(bool value);

        // Actions
        void Attack();
        void DamageHealth(int attack); 
        
        void Move();
        void Ability();
        void Die();
    }
}