using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    #region Init
    static DrawManager Dm;

    public static DrawManager _DM
    {
        get
        {
            if (Dm == null)
            {
                Debug.LogError("DrowManager is NULL");
            }

            return Dm;
        }
    }

    private void Awake()
    {
        Dm = this;
    }
    #endregion
    List<Vector3> drawnPositionsList = new List<Vector3>();
    public List<Vector3> DrawnPositionsList
    {
        get
        {
            return drawnPositionsList;
        }
        set
        {
            drawnPositionsList = value;
        }
    }

    Dictionary<LineRenderer, List<GameObject>> carPartsPositionsOnTheLineDict =
        new Dictionary<LineRenderer, List<GameObject>>();
    public Dictionary<LineRenderer, List<GameObject>> CarPartsPositionsOnTheLineDict
    {
        get
        {
            return carPartsPositionsOnTheLineDict;
        }
        set
        {
            carPartsPositionsOnTheLineDict = value;
        }
    }


    LineRenderer lastDrawnLine;
    public LineRenderer LastDrawnLine
    {
        get
        {
            return lastDrawnLine;
        }
        set
        {
            lastDrawnLine = value;
        }
    }

}
