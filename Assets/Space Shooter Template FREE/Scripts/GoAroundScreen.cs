using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAroundScreen : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Boundary")
        {
            Debug.Log("Collided with Boundary!");
            //get BoxCollider2D and store the value.
            var boxCollider = collision.GetComponent<BoxCollider2D>();
            
            //locate player's location
            float playerPosX = transform.position.x;
            float playerPosY = transform.position.y;

            //if player is off the boundary, bring to opposite.
            if((playerPosX <= boxCollider.bounds.min.x) || (playerPosX >= boxCollider.bounds.max.x))
            {
                playerPosX = transform.position.x * -1;
            }

            if((playerPosY <=boxCollider.bounds.min.y) || (playerPosY >= boxCollider.bounds.max.y))
            {
                playerPosY = transform.position.y * -1;
            }

            //update X and Y positions of the player.
            transform.position = new Vector3(playerPosX, playerPosY, 0);
        }
    }
}
