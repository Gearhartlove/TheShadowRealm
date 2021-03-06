using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Monster;
using UnityEngine;
using UnityEngine.UI;

public class Strategy : MonoBehaviour
{
    private Board board;

    private int ShopYPos = 1;
    private int ShopXPos_1 = 1;
    private int ShopXPos_2 = 4;
    private int ShopXPos_3 = 7;
    private int ShopXPos_4 = 10;
    private List<int> ShopXPos;

    private int Currency = 0;
    private int[] RoundCurrency = new int[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6};
    private int Round = 0;

    private GameObject ShopMonster1;
    private GameObject ShopMonster2;
    private GameObject ShopMonster3;
    private GameObject ShopMonster4;

    private List<GameObject> ShopMonsters;

    public void SetBoard(Board board)
    {
        this.board = board;
    }

    [SerializeField] private GameFlowManager _gameFlowManager;
    [SerializeField] private GameObject ShopTeam;
    [SerializeField] private ShopUnitUI ShopUnitUI;
    private MonsterBuilder MonsterBuilder;
    MonsterValueList ShopValues;
    private List<List<MonsterType>> ValueLists;


    // Start is called before the first frame update
    void Awake()
    {
        ShopValues = new MonsterValueList();
        MonsterBuilder = _gameFlowManager.getMonsterBuilder();
        ValueLists = new List<List<MonsterType>>() { ShopValues.GetValueOneMonsters(), ShopValues.GetValueTwoMonsters(), ShopValues.GetValueThreeMonsters(), ShopValues.GetValueFourMonsters() };
        ShopXPos = new List<int> { ShopXPos_1, ShopXPos_2, ShopXPos_3, ShopXPos_4 };
        ShopMonsters = new List<GameObject> { ShopMonster1, ShopMonster2, ShopMonster3, ShopMonster4 };
    }

    // Update is called once per frame
    void Update()
    {
        // Adding code so monsters do not spawn unless it is currently the strategy phase 
        if (_gameFlowManager.GetCurrentPhase == "Strategy") {
            // TODO: CADE PLEASE READ
            // Kristoff: I changed this code because the code below was giving me an "InvalidOperationException" for
            // trying to iterate over the ShopMonsters List. You can change this back Cade if it is causing you problems.
            // Please tell me if you do so
            for (int i = 0; i < ShopMonsters.Count; i++) {
                if (!ShopMonsters[i]) {
                    // SpawnMonster(ShopMonsters[i]);
                    SpawnMonster(i);
                }
            }
            
            // OLD CODE 
            // foreach (GameObject monster in ShopMonsters)   
            // {
            //     if (!monster)
            //     {
            //         SpawnMonster(ShopMonsters.IndexOf(monster) + 1);
            //     }
            // }
        }
    }

    private void SpawnMonster(int shopSlot)
    {
        MonsterType newMonster = MonsterType.Goblin;
        int xPos = ShopXPos_1;
        int maxValue = RoundCurrency[Round];
        int randValue = Random.Range(1, maxValue + 1);
        int randMonster;
        List<MonsterType> monsters;

        monsters = ValueLists[randValue - 1];
        randMonster = Random.Range(0, monsters.Count);
        newMonster = monsters[randMonster];


        switch (shopSlot)
        {
            case 1:
                xPos = ShopXPos_1;
                ShopMonster1 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                ShopMonsters[0] = ShopMonster1;
                IMonster ShopMonster1Component = ShopMonster1.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(1, ShopMonster1Component.GetValue(), ShopMonster1Component.GetAttack(), ShopMonster1Component.GetHealth(), ShopMonster1Component.GetMovement());
                break;
            case 2:
                xPos = ShopXPos_2;
                ShopMonster2 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                ShopMonsters[1] = ShopMonster2;
                IMonster ShopMonster2Component = ShopMonster2.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(2, ShopMonster2Component.GetValue(), ShopMonster2Component.GetAttack(), ShopMonster2Component.GetHealth(), ShopMonster2Component.GetMovement());
                break;
            case 3:
                xPos = ShopXPos_3;
                ShopMonster3 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                ShopMonsters[2] = ShopMonster3;
                IMonster ShopMonster3Component = ShopMonster3.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(3, ShopMonster3Component.GetValue(), ShopMonster3Component.GetAttack(), ShopMonster3Component.GetHealth(), ShopMonster3Component.GetMovement());
                break;
            case 4:
                xPos = ShopXPos_4;
                ShopMonster4 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                ShopMonsters[3] = ShopMonster4;
                IMonster ShopMonster4Component = ShopMonster4.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(4, ShopMonster4Component.GetValue(), ShopMonster4Component.GetAttack(), ShopMonster4Component.GetHealth(), ShopMonster4Component.GetMovement());
                break;
        }
    }

    public void PurchaseMonster(IMonster monster, int shopSlot, GameObject monsterObject)
    {
        if (monster.GetValue() > Currency)
        {
            // Don't allow monster to be purchased
            // monster.SetPosition(ShopXPos[shopSlot], ShopYPos);
            monsterObject.GetComponent<Grabbable>().ResetPosition();
        } else
        {
            // Buy the monster, add it to the party
            Currency -= monster.GetValue();
            GameObject currentShopMonster = ShopMonsters[shopSlot];
            ShopMonsters[shopSlot] = null;
            currentShopMonster.transform.SetParent(GameObject.Find("PlayerTeam").transform);
        }
    }

    public void MoveMonster(GameObject monster)
    {
        IMonster movedMonster = monster.GetComponent<IMonster>();
        
        // Check if trying to sacrifice monster
        if (movedMonster.GetX() > 8 && movedMonster.GetX() < 11 && movedMonster.GetY() > 5)
        {
            if (ShopMonsters.Contains(monster))
            {
                monster.GetComponent<Grabbable>().ResetPosition();
            } else
            {
                SacrificeMonster(monster, movedMonster);
            }
        }
        else if (ShopMonsters.Contains(monster))
        {
            if(movedMonster.GetX() != ShopXPos[ShopMonsters.IndexOf(monster)] || movedMonster.GetY() != ShopYPos)
            PurchaseMonster(movedMonster, ShopMonsters.IndexOf(monster), monster);
        }
    }

    public void SacrificeMonster(GameObject monsterObject, IMonster monster)
    {
        int returnedValue = monster.GetValue() - 1;
        if (returnedValue <= 0)
        {
            returnedValue = 1;
        }
        Currency += returnedValue;
        Destroy(monsterObject);
    }


    public void StartPhase()
    {
        Round++;
        if (Round > 13)
        {
            Currency = RoundCurrency[13];
        } else
        {
            Currency = RoundCurrency[Round - 1];
        }
        SpawnMonster(1);
        SpawnMonster(2);
        SpawnMonster(3);
        SpawnMonster(4);
    }

    public int GetCurrency()
    {
        return Currency;
    }

    public void RollShop()
    {
        if (Currency >= 1)
        {
            Currency--;
            foreach (GameObject monster in ShopMonsters)
            {
                GameObject.Destroy(monster);
            }
        }
    }
}
