using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Monster;
using UnityEngine;

public class Board : MonoBehaviour {

    private int board_size_x = 12;
    private int board_size_y = 8;
    private Cell[,] board;
    public Cell GetCell(int x, int y) {
        return board[y, x];
    }

    private List<IMonster> monsters;
    public List<IMonster> GetMonsters => monsters;

    private int player_monster_count = -1;
    public int GetPlayerMonsterCount => player_monster_count;
    private int enemy_monster_count = -1;
    public int GetEnemyMonsterCount => enemy_monster_count;
    
    // initialize the board with cells
    public Board() {
        monsters = new List<IMonster>();
        board = new Cell[board_size_y, board_size_x];
        for (int i = 0; i < board_size_y; i++) {
            for (int j = 0; j < board_size_x; j++) {
                board[i, j] = new Cell(); 
            }
        }
    }

    // print out the board for debugging purposes
    private void DebugBoard() { 
        foreach (var c in board) {
            Debug.Log(c.GetCellType);
        } 
    }

    // public bool CheckMonster() {
    //     
    // }

    public bool CheckEnemyMonster(int x, int y) {
        if (IS_OOB(x,y)) return false; // not an enemy if out of bounds
        return GetCell(x, y).enemy;
    }

    // protects searches of the board from being out of bounds
    private bool IS_OOB(int x, int y) {
        if (x >= board_size_x || x <= 0 ||
            y >= board_size_y || y <= 0) {
            return true;
        }
        return false;
    }
}


