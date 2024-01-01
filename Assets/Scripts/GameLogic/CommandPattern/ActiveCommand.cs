using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCommand : ICommand
{
    private UIEditor _uiEditor;

    public ActiveCommand(UIEditor editor)
    {
        _uiEditor = editor;
    }

    public IEnumerator AsyncExec()
    {
        throw new System.NotImplementedException();
    }

    public void Exec()
    {
        _uiEditor.Active();
    }

}
