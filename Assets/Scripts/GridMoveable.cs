using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridMoveable : MonoBehaviour
{
    private GridObject gridObject;
    public Vector2 movingDirection = new Vector2(-1 ,-1);
    // Start is called before the first frame update
    void Start()
    {
        gridObject = this.GetComponent<GridObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool move(Vector2 direction)
    {
        // Tries to move to the given direction
        // If failed, return false, otherwise return true;
        if(ValidityCheck(this.gridObject.gridPosition + direction))
        {
            movingDirection = direction;
            return true;
        }
        return false;
    }

    private void LateUpdate()
    {
        if(this.movingDirection != new Vector2(-1, -1)) { this.gridObject.gridPosition += movingDirection; }
        this.movingDirection = new Vector2(-1, -1);
    }

    private bool ValidityCheck(Vector2 target)
    {
        // Interaction with boundary
        if (target.x < 1 ||
            target.y < 1 ||
            target.x > gameManager.Instance.gridDimensions.x ||
            target.y > gameManager.Instance.gridDimensions.y)
        { return false; }

        // Interaction with other blocks
        GridObject[] blocks = FindObjectsOfType<GridObject>();
        GridObject blockMatching = null;  // There should only be 1 block on a single grid. 
        foreach (GridObject block in blocks)
        {
            if (block.gridPosition == target)
            {
                blockMatching = block;
                break;
            }
        }

        if(blockMatching != null)
        {
            switch (blockMatching.tag)
            {
                case "Wall":
                    return false;
                case "Slick":
                    if(blockMatching.GetComponent<GridMoveable>().move(target - gridObject.gridPosition)) { return true; }
                    return false;
            }
        }
        // Passes all check
        return true;
    }
}
