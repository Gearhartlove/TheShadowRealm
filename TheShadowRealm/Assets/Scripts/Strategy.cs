using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Monster;
using UnityEngine;
using UnityEngine.UI;

public class Strategy : MonoBehaviour
{
    private Board board;

    public void SetBoard(Board board)
    {
        this.board = board;
    }

    [SerializeField] private GameFlowManager _gameFlowManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
