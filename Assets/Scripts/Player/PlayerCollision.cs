using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        rb = GetComponentInParent<Rigidbody>();

        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hit an obstacle!");
            //movement.enabled = false;
            movement.playerDead = true;
            movement.enabled = false;
            rb.freezeRotation = false;

            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
