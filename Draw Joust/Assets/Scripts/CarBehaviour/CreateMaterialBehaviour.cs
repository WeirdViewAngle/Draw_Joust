using UnityEngine;

public class CreateMaterialBehaviour : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public ConfigurableJoint configJoint;
    public Collider carPartColl;
    private void OnEnable()
    {
        GameManager.Instance.gameStartedEvent.AddListener(GameStarted);
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    void GameStarted()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        carPartColl.isTrigger = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Object collided: " + collision.gameObject.name);
    }

}
