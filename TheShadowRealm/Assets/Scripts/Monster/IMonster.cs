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
        
        IMonster GetTarget();
        
        bool GetInRange();
        void SetInRange(bool value);

        bool GetIsEnemy();
        void SetIsEnemy(bool value);

        // Actions
        void Attack();
        void Move();
        void Ability();
        void Die();
    }
}