using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hit an obstacle!");
            movement.enabled = false;

            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
