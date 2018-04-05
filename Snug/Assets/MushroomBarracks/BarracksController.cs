using System.Collections;
using UnityEngine;

public class BarracksController : MonoBehaviour {

    public GameObject barracksPanel;
    bool isActive = true;

    public void OnMouseDown()
    {
        barracksPanel.SetActive(isActive);
        isActive = !isActive;
    }
}
