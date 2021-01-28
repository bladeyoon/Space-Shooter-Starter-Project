using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance;

    public int jump;

    public TextMeshProUGUI jumpText;

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    /*
    private void FixedUpdate()
    {
        if()
    }

    private void FixedUpdate()
    {
        if (scoreText.text != score.ToString())
        {
            scoreText.text = score.ToString();
        }
    }

    */

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        Destruction();
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Destroy(gameObject);
    }
}
















