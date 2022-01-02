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

    private int Currency = 0;
    private int[] RoundCurrency = new int[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6};
    private int Round = 0;

    private GameObject ShopMonster1;
    private GameObject ShopMonster2;
    private GameObject ShopMonster3;
    private GameObject ShopMonster4;

    public void SetBoard(Board board)
    {
        this.board = board;
    }

    [SerializeField] private GameFlowManager _gameFlowManager;
    [SerializeField] private GameObject ShopTeam;
    [SerializeField] private ShopUnitUI ShopUnitUI;
    private MonsterBuilder MonsterBuilder;
    MonsterValueList ShopValues;

    // Start is called before the first frame update
    void Awake()
    {
        ShopValues = new MonsterValueList();
        MonsterBuilder = _gameFlowManager.getMonsterBuilder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMonster(int shopSlot)
    {
        MonsterType newMonster = MonsterType.Goblin;
        int xPos = ShopXPos_1;
        int maxValue = RoundCurrency[Round];
        int randValue = Random.Range(1, maxValue + 1);
        int randMonster;
        List<MonsterType> monsters;
        switch (randValue)
        {
            case 1:
                monsters = ShopValues.GetValueOneMonsters();
                randMonster = Random.Range(0, monsters.Count);
                newMonster = monsters[randMonster];
                break;
            case 2:
                monsters = ShopValues.GetValueTwoMonsters();
                randMonster = Random.Range(0, monsters.Count);
                newMonster = monsters[randMonster];
                break;
            case 3:
                monsters = ShopValues.GetValueThreeMonsters();
                randMonster = Random.Range(0, monsters.Count);
                newMonster = monsters[randMonster];
                break;
            case 4:
                monsters = ShopValues.GetValueFourMonsters();
                randMonster = Random.Range(0, monsters.Count);
                newMonster = monsters[randMonster];
                break;
        }
        switch (shopSlot)
        {
            case 1:
                xPos = ShopXPos_1;
                ShopMonster1 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                Debug.Log(ShopMonster1);
                IMonster ShopMonster1Component = ShopMonster1.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(1, ShopMonster1Component.GetValue(), ShopMonster1Component.GetAttack(), ShopMonster1Component.GetHealth(), ShopMonster1Component.GetMovement());
                break;
            case 2:
                xPos = ShopXPos_2;
                ShopMonster2 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                IMonster ShopMonster2Component = ShopMonster2.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(2, ShopMonster2Component.GetValue(), ShopMonster2Component.GetAttack(), ShopMonster2Component.GetHealth(), ShopMonster2Component.GetMovement());
                break;
            case 3:
                xPos = ShopXPos_3;
                ShopMonster3 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                IMonster ShopMonster3Component = ShopMonster3.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(3, ShopMonster3Component.GetValue(), ShopMonster3Component.GetAttack(), ShopMonster3Component.GetHealth(), ShopMonster3Component.GetMovement());
                break;
            case 4:
                xPos = ShopXPos_4;
                ShopMonster4 = MonsterBuilder.GenerateMonster(newMonster, ShopTeam, xPos, ShopYPos);
                IMonster ShopMonster4Component = ShopMonster4.GetComponent<IMonster>();
                ShopUnitUI.UpdateStats(4, ShopMonster4Component.GetValue(), ShopMonster4Component.GetAttack(), ShopMonster4Component.GetHealth(), ShopMonster4Component.GetMovement());
                break;
        }
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
}
