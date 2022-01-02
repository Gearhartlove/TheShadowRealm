using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Monster;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour {
    private Board board;

    public void SetBoard(Board board) {
        this.board = board;
    }

    [SerializeField] private GameFlowManager _gameFlowManager;
    [SerializeField] private DebugUIPanel debug_text;


    [SerializeField] private bool player_win = false;
    [SerializeField] private bool enemy_win = false;

    private int combat_turn = 0;

    /// <summary>
    /// Contains all of the tasks which execute during combat, including: Movement, Attacking, State Changes,
    /// and Game Assessment.
    /// </summary>
    public void CombatUpdate() {
        ++combat_turn;
        // debug_text.AppendText(combat_turn.ToString());
        MonsterRangeUpdate();
        // MonsterActions(); // if monster in range => attack, else move toward closest enemy 
        // MonsterStatusCheck(); // which monster's died?
        // AssessGame(); // has either side won?
    }

    /// <summary>
    /// Check range of monster and see if another monster is in that radius
    /// </summary>
    private void MonsterRangeUpdate() {
        foreach (IMonster monster in board.GetMonsters) {
            int r = monster.GetRange();
            monster.SetInRange(false);
            // look around the monsters for enemy monsters. Account for different range values.
            while (r > 0) {
                if (
                    board.CheckEnemyMonster(monster.GetX() + r, monster.GetY()) ||
                    board.CheckEnemyMonster(monster.GetX() - r, monster.GetY()) ||
                    board.CheckEnemyMonster(monster.GetX(), monster.GetY() + r) ||
                    board.CheckEnemyMonster(monster.GetX(), monster.GetY() - r)) {
                    monster.SetInRange(true); // set monster in range to true
                }

                r--;
            }
        }
    }

    private void MonsterActions() {
        // If monster in range => attack, else move toward closest enemy
        foreach (IMonster monster in board.GetMonsters) {
            if (monster.GetInRange()) {
                monster.Attack();
            }
            else {
                monster.Move();
            }
        }
    }

    private void MonsterStatusCheck() {
        foreach (IMonster monster in board.GetMonsters) {
            if (monster.GetHealth() <= 0) {
                monster.Die();
            }
        }
    }

    // private void AssessGame() {
    //     if (board.GetPlayerMonsterCount == 0) {
    //     }
    //
    //     if (board.GetEnemyMonsterCount == 0) {
    //     }
    //
    //     _gameFlowManager.AssessGame();
    // }

    public void AssessGame() {
        if (player_win && enemy_win) {
            Draw();
        }
        else if (player_win && !enemy_win) {
            PlayerWin();
        }
        else if (!player_win && enemy_win) {
            EnemyWin();
        }
    }

    // Possible end states for the game
    private void PlayerWin() {
    }

    private void EnemyWin() {
    }

    private void Draw() {
    }
}