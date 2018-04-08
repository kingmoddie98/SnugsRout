using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //contains navemesh

public class KirMovement : MonoBehaviour {

    public bool moving;
    public NavMeshAgent agent;
    public Transform pointer;
	
	// Update is called once per frame
	void Update () {
        //activate the navmeshagent

        if(moving)
        {
            agent.SetDestination(pointer.position);
            agent.Resume();
        }
		
	}
}
