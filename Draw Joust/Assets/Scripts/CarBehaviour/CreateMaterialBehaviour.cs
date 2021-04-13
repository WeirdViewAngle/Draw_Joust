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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag != "Tires" && configJoint.connectedBody == null)
    //    {
    //        if (other.GetComponent<ConfigurableJoint>().connectedBody != _rigidbody)
    //        {
    //            configJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
    //            configJoint.connectedAnchor = other.ClosestPointOnBounds(transform.position);
    //        }
    //    }

    //}

    void GameStarted()
    {
        ////if (configJoint.connectedBody == null)
        //{
        //    float closestDistance = 1000;
        //    GameObject closestGO = null;
        //    foreach (LineRenderer key in DrawManager._DM.CarPartsPositionsOnTheLineDict.Keys)
        //    {
        //        foreach (GameObject GO in DrawManager._DM.CarPartsPositionsOnTheLineDict[key])
        //        {
        //            float newDistance = Vector3.Distance(this.gameObject.transform.position, GO.transform.position);
        //            if (newDistance < closestDistance)
        //            {
        //                closestGO = GO;
        //            }

        //        }

        //    }
        //    if (closestGO != null && closestGO != this.gameObject)
        //        configJoint.connectedBody = closestGO.GetComponent<Rigidbody>();
        //}

        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        carPartColl.isTrigger = false;
    }

}
