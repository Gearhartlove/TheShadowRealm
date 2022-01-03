using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Monster;
using UnityEngine;

public class Cell {
    
    private Tile cell_type;
    public Tile GetCellType => cell_type;
    public IMonster monster;
    public bool enemy = false;
    
    public Cell() {
        cell_type = Tile.Flat; // temporary, implement random generation eventually
    }

    public void SetMonster(IMonster monster) {
        // this.monster = null;
        this.monster = monster;
        enemy = true;
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
