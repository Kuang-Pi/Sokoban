using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class StickyBlock : MonoBehaviour
{
    private GridMoveable gridMoveable;
    private GridObject gridObject;
    // Start is called before the first frame update
    void Start()
    {
        gridMoveable = this.GetComponent<GridMoveable>();
        gridObject = this.GetComponent<GridObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StickyMove(GameObject other)
    {
        if (other.GetComponent<GridMoveable>().isNear(this.gridObject))
        {
            gridMoveable.move(other.GetComponent<GridMoveable>().movingDirection);
        }

    }
}
