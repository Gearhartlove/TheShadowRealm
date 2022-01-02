using System;
using System.Collections.Generic;
using Monster;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace {
    public class GameFlowManager : MonoBehaviour {

        [SerializeField]
        private MonsterPrefabList monster_prefab_list;
        
        private int monster_cap = 8;
        [SerializeField] private GameObject player_monsters;
        [SerializeField] private GameObject enemy_monsters;
        
        // add monster by switching on lowercase monster type
        public void add_monster(MonsterType monster,  GameObject monster_list) {
            
            // can't add more monsters than current amount of monsters
            if (monster_list.transform.childCount <= monster_cap) {
                switch (monster) {
                    case MonsterType.Goblin:
                        Instantiate(monster_prefab_list.goblin_prefab, monster_list.transform);
                        // debug_text.AppendText(monster.ToString() + " added to board");
                        break;
                }
            }
        }
        [SerializeField]
        private Board board;
        [SerializeField] private Combat combat;
        [SerializeField] private DebugUIPanel debug_text;

        // private GamePhases current_game_state = GamePhases.Combat;

        // Starts the flow of the game, starting with X (what you call)
        private void Start() {
            add_monster(MonsterType.Goblin, player_monsters);
            CombatPhase();
            //StrategyPhase();
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