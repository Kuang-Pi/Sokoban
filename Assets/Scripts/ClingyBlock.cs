using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClingyBlock : MonoBehaviour
{
    GridObject gridObject;
    public UnityEvent pullingBlock;
    // Start is called before the first frame update
    void Start()
    {
        gridObject = GetComponent<GridObject>();
        pullingBlock.AddListener(TryToPull);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TryToPull()
    {
        List<GameObject> players = new List<GameObject> ();
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(player);
        }

        foreach(GameObject player in players)
        {
            if (player.GetComponent<GridMoveable>().isNear(gridObject)) { this.GetComponent<GridMoveable>().move(player.GetComponent<GridObject>().gridPosition - gridObject.gridPosition); }
        }
    }
}
