using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextScript : MonoBehaviour {
    public static Text scoreText;
    public static int score = 0;

    public static bool isEnabled = true;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!isEnabled) enabled = isEnabled;
    }

    public static void setScoreTxt(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
}
