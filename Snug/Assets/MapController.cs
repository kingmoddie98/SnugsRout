using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    //inefficent for now
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;

    public Map gameboard;

	// Use this for initialization
	void Start () {

        // create about 10k tiles
        gameboard = new Map();

        //Create Gameobject for every tile in the map
        for(int i=0; i < gameboard.width; i++)
        {
            for (int j=0; j <gameboard.height; j++)
            {
                GameObject tileGo = new GameObject("Tile_" + i + "_" + j);
                tileGo.transform.position = new Vector3(i, j);

                SpriteRenderer tileSP = tileGo.AddComponent<SpriteRenderer>();
                tileSP.sprite = s1;
            }

        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

