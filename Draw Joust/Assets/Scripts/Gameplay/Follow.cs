
/* Unmerged change from project 'Assembly-CSharp.Player'
Before:
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
After:
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
*/
using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject objToFollow;

    void LateUpdate()
    {
        transform.position = new Vector3(objToFollow.transform.position.x,
                                        objToFollow.transform.position.y,
                                        transform.position.z);

        //transform.Translate(Vector3.right * 0.05f, Space.World);
    }
}
