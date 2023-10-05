using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private GridMoveable gridObject;
    // Start is called before the first frame update
    void Start()
    {
        gridObject = this.GetComponent<GridMoveable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gridObject.move(new Vector2(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gridObject.move(new Vector2(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gridObject.move(new Vector2(-1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gridObject.move(new Vector2(1, 0));
        }

        // Pull
        if (Input.GetKey(KeyCode.Space))
        {
            foreach(GameObject clingyBlock in GameObject.FindGameObjectsWithTag("Clingy"))
            {
                clingyBlock.GetComponentInParent<ClingyBlock>().pullingBlock.Invoke();
            }
        }
    }
}
