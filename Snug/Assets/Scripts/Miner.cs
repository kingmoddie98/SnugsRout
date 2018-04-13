using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        var mineList = GameObject.FindGameObjectsWithTag("Mine");
        for (var i = 0; i < mineList.Length; i++)
        {
            //this.transform.position 
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
