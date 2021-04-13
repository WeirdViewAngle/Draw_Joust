
/* Unmerged change from project 'Assembly-CSharp.Player'
Before:
using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
After:
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
*/
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region  Init
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        gameStartedEvent.AddListener(GameStarted);
    }
    #endregion


    public UnityEvent gameStartedEvent;
    public bool gameStarted;

    public GameObject leftWeal, rightWeal, Player, Car, lineObject, carMaterialPart, createPlane;
    public SphereCollider carMaterialPartColl;

    public void GameStarted()
    {
        gameStarted = true;
        Destroy(createPlane);
    }
}
