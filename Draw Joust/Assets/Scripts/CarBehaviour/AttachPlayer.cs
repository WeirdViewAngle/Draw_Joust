using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public Rigidbody _rigidbody;

    private void Start()
    {
        GameManager.Instance.gameStartedEvent.AddListener(GameStart);
    }

    private void OnCollisionEnter(Collision collision)
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
    }

    void GameStart()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
