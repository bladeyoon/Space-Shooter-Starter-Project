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
    public GameObject destructionFX;            // VFX when player is dead.
    GameObject invincibleFX;                    // VFX when player is invincible.
    public static Player instance;              // unique instance of the script for easy access to the script.

    public int jump;                            // player life.

    public TextMeshProUGUI jumpText;            // Text showing player's remaining life.
    public LevelController levelController;     // Reference to level controller.
    public bool isInvincible;                   // true or false for player's invincibility.
    public int invincibilityTime;               // Seconds of player's invincibility lasting.
    public Vector3 defaultSpawn;                // default spawn location when game starts or revive.


    private void Awake()
    {
        defaultSpawn = new Vector3(0, -7, 0);
        if (instance == null) 
            instance = this;
    }

    private void Start()
    {
        invincibleFX = GameObject.Find("InvincibleFX");
        levelController = FindObjectOfType<LevelController>();
        jumpText.text = jump.ToString();
        SpawnPlayer();
        //invincibleFX.SetActive(false);
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        Destruction();
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        if (! isInvincible)
        {
            jump--;
            jumpText.text = jump.ToString();
            Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
            
            if (isGameOver())
            {
                foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
                {
                    rend.enabled = false;
                }
                isInvincible = true;
                StartCoroutine(levelController.DisplayGameOver());
            }

            else
            {
                SpawnPlayer();
            }
        }
    }

    bool isGameOver()
    {
        if (jump == 0)
        {
            //enabled = false;
            return true;
        }
            return false;
    }
    
    IEnumerator TimeOfInvincibility()
    {
        float time = 0f;
        while (time <= invincibilityTime)
        {
            isInvincible = true;
            time += Time.deltaTime;
            yield return null;
        }
        isInvincible = false;
        invincibleFX.SetActive(false);
    }

    void SpawnPlayer()
    {
        if (jump > 0)
        {
            placePlayer(false);
        }
        invincibleFX.SetActive(true); //Activate VFX when invincible.
        StartCoroutine(TimeOfInvincibility());
        Debug.Log("Starting Coroutine of Invincible.");
    }

    void placePlayer(bool retry)
    {
        if (! retry)
        {
            gameObject.transform.position = defaultSpawn;
        }
        if (isTouching())
        {
            tryNewPlayerSpawnPosition();
        }
    }

    void tryNewPlayerSpawnPosition()
    {
        int[] choices = new int[] { -1, 1 };
        int pixelsToMove = 60 * (choices[UnityEngine.Random.Range(0, 2)]);
        transform.position += new Vector3(transform.position.x + pixelsToMove, 0, 0);
        placePlayer(true);
    }

    bool isTouching()
    {
        return gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("EnemyObject"));
    }
}
