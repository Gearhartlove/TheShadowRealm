using System;
using System.Collections.Generic;
using Monster;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace {
    public class GameFlowManager : MonoBehaviour {
        [SerializeField] MonsterBuilder monster_builder;
        private string current_phase;
        public string GetCurrentPhase => current_phase;

        public MonsterBuilder getMonsterBuilder() {
            return monster_builder;
        }

        private GameObject player_monsters;
        private GameObject enemy_monsters;
        private GameObject shop_monsters;


        [SerializeField] private Board board;

        [SerializeField] private Combat combat;

        [SerializeField] private Strategy strategy;
        // [SerializeField] private DebugUIPanel debug_text;

        // private GamePhases current_game_state = GamePhases.Combat;

        // Starts the flow of the game, starting with X (what you call)
        private void Start() {
            SetupGame();
            monster_builder.GenerateMonster(MonsterType.Goblin, player_monsters, 7, 7);
            monster_builder.GenerateMonster(MonsterType.Goblin, enemy_monsters, 7, 6, isEnemy: true);
            monster_builder.GenerateMonster(MonsterType.Crow, enemy_monsters, 1, 1, isEnemy: true);
            monster_builder.GenerateMonster(MonsterType.Kobold, enemy_monsters, 1, 1, isEnemy: true);
            monster_builder.GenerateMonster(MonsterType.Kobold, enemy_monsters, 1, 1, isEnemy: true);
            monster_builder.GenerateMonster(MonsterType.Skeleton_Archer, enemy_monsters, 1, 1, isEnemy: true);
            monster_builder.GenerateMonster(MonsterType.Skeleton_Archer, enemy_monsters, 1, 1, isEnemy: true);
            monster_builder.GenerateMonster(MonsterType.Spider, enemy_monsters, 1, 1, isEnemy: true);
            CombatPhase();
        }

        private void SetupGame() {
            current_phase = "Setup";
            player_monsters = GameObject.Find("PlayerTeam");
            enemy_monsters = GameObject.Find("EnemyTeam");
            shop_monsters = GameObject.Find("ShopTeam");
        }

        private void StrategyPhase() {
            current_phase = "Strategy";
            strategy.StartPhase();
        }


        private void CombatPhase() {
            current_phase = "Combat";
            foreach (var monster in player_monsters.GetComponentsInChildren<IMonster>()) {
                board.GetMonsters.Add(monster);
            }

            foreach (var monster in enemy_monsters.GetComponentsInChildren<IMonster>()) {
                board.GetMonsters.Add(monster);
            }
            // Loop the Run combat phase until win or draw
            // debug_text.AppendText("test");
        }
    }

    // enum GamePhases {
    //     Strategy,
    //     Setup,
    //     Combat,
    //     PostCombat,
    // }
}