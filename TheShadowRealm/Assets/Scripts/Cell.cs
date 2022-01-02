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
}

// Types which the cells can be
public enum Tile {
    Initial, 
    Tombstone,
    Flat,
    Hill,
    Ramp,
}
