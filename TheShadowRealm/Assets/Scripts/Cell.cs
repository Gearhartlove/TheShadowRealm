using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Cell {
    
    private Tile cell_type;
    public Tile GetCellType => cell_type;
    public bool monster = false;
    public bool enemy = false;

    public Cell() {
        cell_type = Tile.Flat; // temporary, implement random generation eventually
    }

    // randomly assign a tile to a value
    private void ProceduralGeneration() {
        
    }
    
}

// Types which the cells can be
public enum Tile {
    Initial, 
    Tombstone,
    Flat,
    Hill,
    Ramp,
}
