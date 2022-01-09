using UnityEngine;

namespace Monster {
    public class MonsterBuilder : MonoBehaviour {
        [SerializeField] private MonsterPrefabList monster_prefab_list;

        // add monster by switching on lowercase monster type
        public GameObject GenerateMonster(MonsterType monster, GameObject monster_roster, int x, int y,
            bool isEnemy = false) {
            // can't add more monsters than current amount of monsters
            GameObject newMonster = null;
            switch (monster) {
                case MonsterType.Goblin:
                    newMonster = Instantiate(monster_prefab_list.goblin_prefab, new Vector3(transform.position.x + x,
                        transform.position.y - y, 3), transform.rotation, monster_roster.transform);
                    // debug_text.AppendText(monster.ToString() + " added to board");
                    break;
                case MonsterType.Crow:
                    newMonster = Instantiate(monster_prefab_list.crow_prefab, new Vector3(transform.position.x + x,
                        transform.position.y - y, 3), transform.rotation, monster_roster.transform);
                    // debug_text.AppendText(monster.ToString() + " added to board");
                    break;
                case MonsterType.Skeleton_Archer:
                    newMonster = Instantiate(monster_prefab_list.skeleton_archer_prefab, new Vector3(
                        transform.position.x + x,
                        transform.position.y - y, 3), transform.rotation, monster_roster.transform);
                    // debug_text.AppendText(monster.ToString() + " added to board");
                    break;
                case MonsterType.Spider:
                    newMonster = Instantiate(monster_prefab_list.spider_prefab, new Vector3(transform.position.x + x,
                        transform.position.y - y, 3), transform.rotation, monster_roster.transform);
                    // debug_text.AppendText(monster.ToString() + " added to board");
                    break;
                case MonsterType.Kobold:
                    newMonster = Instantiate(monster_prefab_list.kobold_prefab, new Vector3(transform.position.x + x,
                        transform.position.y - y, 3), transform.rotation, monster_roster.transform);
                    // debug_text.AppendText(monster.ToString() + " added to board");
                    break;
            }

            SetupMonster(newMonster, x, y, isEnemy);
            return newMonster;
        }

        private void SetupMonster(GameObject monster, int x, int y, bool isEnemy) {
            IMonster monster_stats = monster.GetComponent<IMonster>();
            monster_stats.SetX(x);
            monster_stats.SetY(y);
            monster_stats.SetIsEnemy(isEnemy);
        }
    }
}