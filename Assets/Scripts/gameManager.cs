using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }
    public Vector2 gridDimensions;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gridDimensions = this.GetComponent<GridMaker>().dimensions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
