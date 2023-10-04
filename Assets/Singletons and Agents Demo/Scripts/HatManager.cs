using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public static HatManager reference;

    public int numberOfHatRings;
    public GameObject hat;
    public GameObject player;
    public Camera cam;
    private int numHats = 0;

    private List<GameObject> hats;

    private void Awake()
    {
        reference = this;
    }

    private void Start()
    {
        CreateHats();
        hats = new List<GameObject>();

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("hat"))
        {
            hats.Add(g);
        }
    }

    private void Update()
    {
        foreach (GameObject g in hats)
        {
            if (Vector3.Distance(g.transform.position, player.transform.position) < 0.5f && !g.GetComponent<Hat>().isOnHead)
            {
                g.transform.parent = player.transform;
                g.transform.localPosition = new Vector3(0, 0.314f + numHats * 0.3f, 0);
                cam.orthographicSize += 0.5f;
                g.GetComponent<Hat>().isOnHead = true;
                numHats++;
            }
        }
    }

    private void CreateHats()
    {
        float distance = 1;
        for (int i = 0; i < numberOfHatRings; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                this.transform.Rotate(new Vector3(0, 0, 1), Random.Range(90, 270));
                SpawnHat(this.transform.position + (this.transform.up * distance) );
            }
            distance += 0.5f;
        }
        this.transform.rotation = Quaternion.identity;
    }

    private void SpawnHat(Vector3 position)
    {
        GameObject.Instantiate(hat, position, Quaternion.identity);
    }
}
