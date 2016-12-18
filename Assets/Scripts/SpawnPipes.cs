using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPipes : MonoBehaviour {
    public GameObject go;
    public List<GameObject> pipes;
    public static List<GameObject> bodRazmaci;

    public static bool isEnabled = true;

    private float razmak = 11.5f;
    private float minGornja = 8.5f;
    private float minDonja = -7.5f;

	void Start () {
        pipes = new List<GameObject>();
        bodRazmaci = new List<GameObject>();

        InvokeRepeating("spawnPipe", 0f, 3f);
	}
	
    
	void Update () {
        if (!isEnabled) enabled = isEnabled;

	    for(int i=0; i<pipes.Count; i++)
        {
            Vector3 currentPosition = pipes[i].transform.position;

            pipes[i].transform.position = new Vector3(currentPosition.x - 0.05f, currentPosition.y, 0);

            if (pipes[i].transform.position.x <= -13f)
            {
                Destroy(pipes[i]);
                pipes.RemoveAt(i);
            }
        }

        for(int i=0; i<bodRazmaci.Count; i++)
        {
            Vector3 currentPosition = bodRazmaci[i].transform.position;

            bodRazmaci[i].transform.position = new Vector3(currentPosition.x - 0.05f, currentPosition.y, 0);
            if(bodRazmaci[i].transform.position.x <= -13f)
            {
                Destroy(bodRazmaci[i]);
                bodRazmaci.RemoveAt(i);
            }
        }
	}

    void spawnPipe()
    {
        go = Instantiate(Resources.Load("Prefabs/pipe")) as GameObject;
        float gornjaY = Random.Range(3.5f, 8.5f);
        go.transform.position = new Vector3(0, gornjaY, 0);
        GameObject pipeGornji = go;
        pipeGornji.tag = "Pipe";

        GameObject razmakObj = Instantiate(Resources.Load("Prefabs/Razmak")) as GameObject;
        razmakObj.tag = "Bod";
        razmakObj.transform.position = new Vector3(pipeGornji.transform.position.x, gornjaY, 0);
        bodRazmaci.Add(razmakObj);

        go = Instantiate(Resources.Load("Prefabs/pipe")) as GameObject;
        go.transform.Rotate(0, 0, 180);
        float donjaY = gornjaY - razmak;
        go.transform.position = new Vector3(0, donjaY, 0);
        GameObject pipeDonji = go;
        pipeDonji.tag = "Pipe";

        pipes.Add(pipeDonji);
        pipes.Add(pipeGornji);
    }
}
