using UnityEngine;

public class DrawCommand : ICommand
{
    GameObject commandGO;
    ConfigurableJoint commandGoConfigurableJoint;
    Rigidbody commandGORb;
    int commandGOIndexInDict;
    public DrawCommand(GameObject child, Rigidbody childRB, int index)
    {
        commandGO = child;
        commandGoConfigurableJoint = commandGO.GetComponent<ConfigurableJoint>();
        commandGORb = childRB;
        commandGOIndexInDict = index;
    }

    public void Do()
    {
        foreach (LineRenderer key in DrawManager._DM.CarPartsPositionsOnTheLineDict.Keys)
        {
            if (commandGOIndexInDict == 0)
            {
                commandGoConfigurableJoint.connectedBody = DrawManager._DM.CarPartsPositionsOnTheLineDict[key]
                    [DrawManager._DM.CarPartsPositionsOnTheLineDict[key].Count - 1]
                    .gameObject.GetComponent<Rigidbody>();
            }
            else
            {
                commandGoConfigurableJoint.connectedBody = DrawManager._DM.CarPartsPositionsOnTheLineDict[key][commandGOIndexInDict - 1]
                    .gameObject.GetComponent<Rigidbody>();
            }
        }
    }

    public void UnDo(LineRenderer line)
    {
        if (DrawManager._DM.CarPartsPositionsOnTheLineDict[line].Contains(commandGO.gameObject))
        {
            DrawManager._DM.CarPartsPositionsOnTheLineDict[line].Remove(commandGO.gameObject);
        }
        commandGO.gameObject.SetActive(false);
    }
}