using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        float camHeight = mainCamera.orthographicSize * 2;
        float camWidth = mainCamera.aspect * camHeight;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(camWidth, camHeight);
    }
}
