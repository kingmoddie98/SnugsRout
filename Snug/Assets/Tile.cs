using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    // X and Y position in the world
    public int X { get; private set; }
    public int Y { get; private set; }


    // Enum for types of terrain that exist
    // Grass you can build and move on
    // Water you cannot build or move on

    enum TileType { grass, water }

    TileType type;
 

    //How quickly can units move through this tile
    float moveSpeed;

    //Can you build on this tile
    bool buildable;


    public Tile (int x, int y)
    {
        Debug.Log("Tile created at: " + x + "," + y);
        X = x;
        Y = y;
        type = TileType.grass;
    }
}
