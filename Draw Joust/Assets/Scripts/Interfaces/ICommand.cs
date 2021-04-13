using UnityEngine;

public interface ICommand
{
    void Do();
    void UnDo(LineRenderer line);
}
