using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject meleeUnit;
    public GameObject rangedUnit;
    private float x = 3.0f;
    private float z = 3.0f;
    Queue<GameObject> unitQueue = new Queue<GameObject>();
    Boolean isStarted = false;

    public void createMeleeUnit()
    {
        unitQueue.Enqueue(meleeUnit);
        if (!isStarted)
        {
            isStarted = true;
            StartCoroutine(spawnUnit());
        }
    }
    public void createRangedUnit()
    {
        unitQueue.Enqueue(rangedUnit);
        if (!isStarted)
        {
            isStarted = true;
            StartCoroutine(spawnUnit());
        }
    }

    IEnumerator spawnUnit()
    {
        while (unitQueue.Count > 0)
        {
            yield return new WaitForSeconds(1);
            GameObject nextUnit = unitQueue.Dequeue();
            Vector3 spawnPosition = new Vector3(x, 0.0f, z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(nextUnit, spawnPosition, spawnRotation);
            z -= .5f;
        }
        isStarted = false;
    }
}
