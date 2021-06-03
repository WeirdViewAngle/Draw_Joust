using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Collider playerColl;

    private void Start()
    {
        GameManager.Instance.gameStartedEvent.AddListener(GameStart);
    }

    private void OnTriggerEnter(Collider collision)
    {
        ConfigurableJoint otherJoint = collision.gameObject.AddComponent<ConfigurableJoint>();
        otherJoint.connectedBody = _rigidbody;
        otherJoint.xMotion = ConfigurableJointMotion.Limited;
        otherJoint.yMotion = ConfigurableJointMotion.Locked;
        otherJoint.zMotion = ConfigurableJointMotion.Locked;
        otherJoint.angularXMotion = ConfigurableJointMotion.Locked;
        otherJoint.angularYMotion = ConfigurableJointMotion.Locked;
        otherJoint.angularZMotion = ConfigurableJointMotion.Locked;

        JointDrive jointDriveX = otherJoint.xDrive;
        jointDriveX.positionSpring = 1000;
        JointDrive jointDriveY = otherJoint.xDrive;
        jointDriveY.positionSpring = 1000;

        otherJoint.xDrive = jointDriveX;
        otherJoint.yDrive = jointDriveY;
        playerColl.isTrigger = false;
        gameObject.layer = 8;
    }

    void GameStart()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
