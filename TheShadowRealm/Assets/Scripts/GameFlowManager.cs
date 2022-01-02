using System;
using System.Collections.Generic;
using Monster;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace {
    public class GameFlowManager : MonoBehaviour {

        [SerializeField] MonsterBuilder monster_builder;
        private GameObject player_monsters;
        private GameObject enemy_monsters;
        
        
        [SerializeField]
        private Board board;
        [SerializeField] private Combat combat;
        // [SerializeField] private DebugUIPanel debug_text;

        // private GamePhases current_game_state = GamePhases.Combat;

        // Starts the flow of the game, starting with X (what you call)
        private void Start() {
            SetupGame();
            monster_builder.GenerateMonster(MonsterType.Goblin, player_monsters, 7,7);
            CombatPhase();
            //StrategyPhase();
        }

        private void SetupGame() {
            player_monsters = GameObject.Find("PlayerTeam");
            player_monsters = GameObject.Find("EnemyTeam");
        }

        private void StrategyPhase() {
            // debug_text.AppendText("[Strategy Phase]");
        }

         
        private void CombatPhase() {
            // debug_text.AppendText("[Combat Phase]");
            // add both enemy monsters and player monsters to monsters list
            var monster_list = player_monsters.GetComponentsInChildren<IMonster>();
            // debug_text.AppendText("IMonsters grabbed");
            foreach (var monster in monster_list) {
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