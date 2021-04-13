using UnityEngine;

public class CarControls : MonoBehaviour
{
    [SerializeField]
    Rigidbody rightWealRB, leftWealRB;
    public float SpeedRate;

    private void Update()
    {

        float inputMoves = Input.GetAxis("Horizontal");
        if (inputMoves != 0 && GameManager.Instance.gameStarted)
        {
            Move(inputMoves);
        }
    }

    private void Move(float direction)
    {
        if (direction > 0)
        {
            rightWealRB.AddForce(Vector3.right * Time.deltaTime * (direction + SpeedRate), ForceMode.Force);
            leftWealRB.AddForce(Vector3.right * Time.deltaTime * (direction + SpeedRate), ForceMode.Force);
        }
        else if (direction < 0)
        {
            direction *= -1;
            leftWealRB.AddForce(Vector3.left * Time.deltaTime * (direction + SpeedRate), ForceMode.Force);
            rightWealRB.AddForce(Vector3.left * Time.deltaTime * (direction + SpeedRate), ForceMode.Force);
        }
    }
}
