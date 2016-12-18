using UnityEngine;
using System.Collections;

public class GameOverTextScript : MonoBehaviour {
    public static string sortingLayerName = "Invisible";
    public static int sortingLayerOrder = 0;
    public static Renderer rend;

	void Start () {
        rend = GetComponent<Renderer>();
	}

    public static void setSortingLayer(string name, int id)
    {
        rend.sortingLayerName = name;
        rend.sortingOrder = id;
    }
}
