using UnityEngine;

namespace Monster {
    public class MonsterBuilder : MonoBehaviour {
        [SerializeField] private MonsterPrefabList monster_prefab_list;
        private int monster_cap = 8;

        // add monster by switching on lowercase monster type
        public void GenerateMonster(MonsterType monster, GameObject monster_roster, int x, int y) {
            // can't add more monsters than current amount of monsters
            if (monster_roster.transform.childCount <= monster_cap) {
                switch (monster) {
                    case MonsterType.Goblin:
                        Instantiate(monster_prefab_list.goblin_prefab, new Vector3(transform.position.x + x,
                            transform.position.y - y, 3), transform.rotation, monster_roster.transform);
                        // debug_text.AppendText(monster.ToString() + " added to board");
                        break;
                }
            }
        }
    }
}