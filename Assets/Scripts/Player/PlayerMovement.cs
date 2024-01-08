using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Drag the Rigid Body of the player here!")]
    public Rigidbody rigidBody;

    public int forwardForce = 500;
    public int sidewaysForce = 300;

    private void FixedUpdate()
    {
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rigidBody.position.y <-1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
