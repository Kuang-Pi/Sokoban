using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private GridMoveable gridObject;
    private bool haveMoved = false;
    private Stack<Dictionary<GridObject, Vector2>> thePast = new Stack<Dictionary<GridObject, Vector2>>();
    // Start is called before the first frame update
    void Start()
    {
        gridObject = this.GetComponent<GridMoveable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(thePast.Count != 0)
            {
                Dictionary<GridObject, Vector2> nextFuture = thePast.Pop();
                foreach(KeyValuePair<GridObject, Vector2> pair in nextFuture)
                {
                    pair.Key.gridPosition = pair.Value;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (thePast.Count != 0)
            {
                Dictionary<GridObject, Vector2> nextFuture = null;
                while (thePast.Count > 0)
                {
                    nextFuture = thePast.Pop();
                }
                foreach (KeyValuePair<GridObject, Vector2> pair in nextFuture)
                {
                    pair.Key.gridPosition = pair.Value;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Record();
                gridObject.move(new Vector2(0, -1));
                haveMoved = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Record();
                gridObject.move(new Vector2(0, 1));
                haveMoved = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Record();
                gridObject.move(new Vector2(-1, 0));
                haveMoved = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Record();
                gridObject.move(new Vector2(1, 0));
                haveMoved = true;
            }

            // Pull
            if (Input.GetKey(KeyCode.Space) && haveMoved)
            {
                foreach (GameObject clingyBlock in GameObject.FindGameObjectsWithTag("Clingy"))
                {
                    clingyBlock.GetComponentInParent<ClingyBlock>().pullingBlock.Invoke();
                }
            }
        }
        haveMoved = false;
    }

    private void Record()
    {
        Dictionary<GridObject, Vector2> objectsPositions = new();
        foreach (GridObject gridObject in FindObjectsOfType<GridObject>())
        {
            objectsPositions.Add(gridObject, gridObject.gridPosition);
        }
        thePast.Push(objectsPositions);
        foreach(KeyValuePair<GridObject, Vector2> keyValuePair in objectsPositions)
        {
            print(keyValuePair.Key.ToString() + keyValuePair.Value.ToString());
        }
    }
}
