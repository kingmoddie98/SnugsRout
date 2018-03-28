using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map  {

    // 2D array of tiles 
    Tile[,] mapTiles;

    // Name of the map
    string fileName;

    // Size of the map
    
    public int width { get; private set; }
    public int height { get; private set; }

    // Default map size
    public Map(int width = 100, int height = 100)
    {

        this.width = width;
        this.height = height;

        mapTiles = new Tile[width, height];

        for(int i=0; i < width; i++)
        {
            for(int j=0; j < height; j++)
            {
                //create the actual array for the gamboard
                mapTiles[i,j] = new Tile(i, j);
            }
        }

    }

    public Tile GetTileAt(int x, int y)
    {
        //check to see if tile is outside bounds of gameboard
        if (x < 0 || x > width -1 || y < 0 || y > height -1)
        {
            return null;
        }
        return mapTiles[x, y];
    }

    public void loadFromFile(string fileName)
    {

    }
}
