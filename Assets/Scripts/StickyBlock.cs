using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sticky only look for adjucent objects that are moveable. 
        GridMoveable[] blocks = FindObjectsOfType<GridMoveable>();
        foreach(GridMoveable block in blocks)
        {
            if (block.movingDirection != new Vector2(-1 ,-1))
            {
                Vector2[] temp = {
                    new Vector2(0, 1),
                    new Vector2(0, -1),
                    new Vector2(1, 0),
                    new Vector2(-1, 0),};
                foreach(Vector2 temp_direction in temp)
                {
                    print("Checking");
                    if (block.gameObject.GetComponent<GridObject>().gridPosition == this.gameObject.GetComponent<GridObject>().gridPosition + temp_direction)
                    {
                        print("Move");
                        this.gameObject.GetComponent<GridMoveable>().movingDirection = block.movingDirection;
                        break;
                    }
                }

            }
        }
    }
}
