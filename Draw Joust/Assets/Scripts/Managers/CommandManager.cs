using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    #region Init
    static CommandManager _instance;
    public static CommandManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("CommandManager is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion



    LineRenderer lastLine;
    public List<LineRenderer> linesAdded = new List<LineRenderer>();
    public Dictionary<LineRenderer, List<ICommand>> _commandBuffer = new Dictionary<LineRenderer, List<ICommand>>();
    public void AddCommand(LineRenderer line, ICommand command)
    {
        if (!_commandBuffer.ContainsKey(line))
        {
            lastLine = line;
            _commandBuffer.Add(line, new List<ICommand>());
            linesAdded.Add(line);
        }
        _commandBuffer[line].Add(command);
    }

    public void UndoLine(LineRenderer line)
    {
        StartCoroutine(UndoCouroutine(line));
        linesAdded.RemoveAt(linesAdded.Count - 1);
        DrawManager._DM.CarPartsPositionsOnTheLineDict.Remove(line);
        _commandBuffer.Remove(line);
    }

    public IEnumerator<LineRenderer> UndoCouroutine(LineRenderer line)
    {
        foreach (ICommand command in _commandBuffer[line])
        {
            command.UnDo(line);
        }
        yield return null;
    }
}
