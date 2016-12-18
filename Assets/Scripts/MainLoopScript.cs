using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainLoopScript : MonoBehaviour {
    public static bool isGameOver = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameOver)
            OnGameOver();
	}

    public void OnGameOver()
    {
        GameOverTextScript.setSortingLayer("Score", 3);
        BirdScript.isEnabled              = false;
        SpawnPipes.isEnabled              = false;
        AnimateBackgroundScript.isEnabled = false;
        ScoreTextScript.isEnabled         = false;
        
    }
    
}
