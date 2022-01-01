using System;

namespace DefaultNamespace {
    public interface IMonster {
        int GetHealth();
        int GetSpeed();
        int GetAttack();
        Tuple<int, int> GetMovement();
        // int GetAbility();
    }
}