using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ObjectToFollow;

    private void Start()
    {
        GameManager.Instance.gameStartedEvent.AddListener(MakeCameraFuther);
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(ObjectToFollow.transform.position.x,
                                        transform.position.y,
                                        transform.position.z);
    }

    public void MakeCameraFuther()
    {
        transform.position = new Vector3(transform.position.x,
                                        transform.position.y + 1,
                                        transform.position.z - 20);
    }
}
