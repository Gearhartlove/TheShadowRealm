using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    private int board_size = 7;
    private Cell[,] board; 
    
    // initialize the board with cells
    void Start() {
        board = new Cell[board_size, board_size];
        for (int i = 0; i < board_size; i++) {
            for (int j = 0; j < board_size; j++) {
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
}


