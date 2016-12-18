using UnityEngine;
using System.Collections;

public class AnimateBackgroundScript : MonoBehaviour {
    public Vector2 speed;
    public static bool isEnabled = true;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.sortingLayerName = "Background";
        rend.sortingOrder = 1;
    }

    void Update()
    {
        if (!isEnabled) enabled = isEnabled;
    }

    void LateUpdate()
    {
        GetComponent<Renderer>().material.mainTextureOffset = speed * Time.time;
    }
}
