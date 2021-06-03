using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject objToFollow;

    void FixedUpdate()
    {
        transform.position = new Vector3(objToFollow.transform.position.x,
                                        objToFollow.transform.position.y,
                                        transform.position.z);
    }
}
