using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDrow : MonoBehaviour
{
    Vector3 mousePosition;
    LineRenderer lineRenderer;

    GameObject leftWhealGO = null, rightWhealGO = null, player = null;
    private void Update()
    {
        #region drawline
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastCollision;

            if (Physics.Raycast(rayOrigin, out rayCastCollision))
            {
                if (rayCastCollision.collider.tag == "CreatePlane")
                {
                    CreateNewLine(true);
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastCollision;


            if (Physics.Raycast(rayOrigin, out rayCastCollision))
            {
                if (rayCastCollision.collider.tag == "CreatePlane" && Vector3.Distance(mousePosition, rayCastCollision.point) > GameManager.Instance.carMaterialPartColl.radius)
                {
                    mousePosition = rayCastCollision.point;
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(mousePosition.x, mousePosition.y, GameManager.Instance.Car.transform.position.z));
                    DrawManager._DM.DrawnPositionsList.Add(mousePosition);
                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastCollision;

            if (Physics.Raycast(rayOrigin, out rayCastCollision))
            {
                if (rayCastCollision.collider.tag == "CreatePlane")
                {
                    StartCoroutine(Draw(lineRenderer));
                }
            }
        }
        #endregion
    }

    IEnumerator Draw(LineRenderer line)
    {
        DrawManager._DM.CarPartsPositionsOnTheLineDict.Add(line, new List<GameObject>());
        foreach (Vector3 point in DrawManager._DM.DrawnPositionsList)
        {

            Vector3 pointModified = new Vector3(point.x, point.y, point.z - 1.25f);


            GameObject newCarPart = Instantiate(GameManager.Instance.carMaterialPart,
                                                pointModified,
                                                Quaternion.identity);

            DrawManager._DM.CarPartsPositionsOnTheLineDict[line].Add(newCarPart);
            newCarPart.transform.parent = GameManager.Instance.Car.transform;
            Rigidbody newCarPartRB = newCarPart.GetComponent<Rigidbody>();
            newCarPartRB.constraints = RigidbodyConstraints.FreezeAll;

            ICommand drowCommand = new DrawCommand(newCarPart, newCarPartRB, DrawManager._DM.CarPartsPositionsOnTheLineDict[line].IndexOf(newCarPart));
            CommandManager.Instance.AddCommand(line, drowCommand);

            yield return new WaitForSeconds(.01f);
        }

        foreach (LineRenderer LR in CommandManager.Instance.linesAdded)
        {
            foreach (DrawCommand drowCommand in CommandManager.Instance._commandBuffer[LR])
            {
                drowCommand.Do();
            }
        }

        AttachWealsAndPlayer();
        DrawManager._DM.DrawnPositionsList.Clear();
        Destroy(GameObject.FindGameObjectWithTag("Line"));
    }



    public void AttachWealsAndPlayer()
    {
        leftWhealGO = GameManager.Instance.leftWeal;
        rightWhealGO = GameManager.Instance.rightWeal;
        player = GameManager.Instance.Player;
        ConfigurableJoint jointLeftWheal = leftWhealGO.GetComponent<ConfigurableJoint>();
        ConfigurableJoint jointRightWheal = rightWhealGO.GetComponent<ConfigurableJoint>();
        ConfigurableJoint jointPlayer = player.GetComponent<ConfigurableJoint>();

        GameObject closestGOToLeft = null, closestGOToRight = null, closestGOToPlayer = null;

        float minDistanceToLeftWheal = 1000f, minDistanceToRightWheal = 1000f, minDistanceToPlayer = 1000;

        foreach (LineRenderer LR in CommandManager.Instance.linesAdded)
        {
            foreach (GameObject carPart in DrawManager._DM.CarPartsPositionsOnTheLineDict[LR])
            {
                float DistanceToLeftWheal = Vector3.Distance(carPart.transform.position, leftWhealGO.transform.position);
                float DistanceToRightWheal = Vector3.Distance(carPart.transform.position, rightWhealGO.transform.position);
                //float DistanceToPlayer = Vector3.Distance(carPart.transform.position, player.transform.position);
                if (DistanceToLeftWheal < minDistanceToLeftWheal)
                {
                    minDistanceToLeftWheal = DistanceToLeftWheal;
                    closestGOToLeft = carPart;
                }
                if (DistanceToRightWheal < minDistanceToRightWheal)
                {
                    minDistanceToRightWheal = DistanceToRightWheal;
                    closestGOToRight = carPart;
                }
                //if(DistanceToPlayer < minDistanceToPlayer)
                //{
                //    minDistanceToPlayer = DistanceToPlayer;
                //    closestGOToPlayer = carPart;
                //}
            }
        }
        jointLeftWheal.connectedBody = closestGOToLeft.GetComponent<Rigidbody>();
        jointRightWheal.connectedBody = closestGOToRight.GetComponent<Rigidbody>();
        //jointPlayer.connectedBody = closestGOToPlayer.GetComponent<Rigidbody>();
    }
    public void CreateNewLine(bool onCreatePlane)
    {
        if (onCreatePlane)
        {
            GameObject lineRendererGO = Instantiate(GameManager.Instance.lineObject);
            lineRenderer = lineRendererGO.GetComponent<LineRenderer>();
            DrawManager._DM.LastDrawnLine = lineRenderer;

            if (DrawManager._DM.DrawnPositionsList.Count != 0)
            {
                DrawManager._DM.DrawnPositionsList.Clear();
            }
        }
    }
}
