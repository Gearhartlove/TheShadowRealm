using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Cell : MonoBehaviour {
    
    private Tile cell_type;
    public Tile GetCellType => cell_type;

    public Cell() {
        cell_type = Tile.Grass; // temporary, implement random generation eventually
    }
    
}

public enum Tile {
    Initial, 
    Obstacle,
    Grass,
    Hill,
    Ramp,
}
