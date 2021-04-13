using UnityEngine;

public class UIManager : MonoBehaviour
{

    private void Start()
    {
        //GameManager.Instance.gameStartedEvent.AddListener();
    }
    public void PlayButton()
    {
        GameManager.Instance.gameStartedEvent.Invoke();
    }

    public void DeleteButton()
    {
        CommandManager.Instance.UndoLine(CommandManager.Instance.linesAdded[CommandManager.Instance.linesAdded.Count - 1]);
    }
}
