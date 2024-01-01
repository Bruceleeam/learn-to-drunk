using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveCommand : ICommand
{
    private UIEditor _uiEditor;

    public DeactiveCommand(UIEditor editor)
    {
        _uiEditor = editor;
    }

    public IEnumerator AsyncExec()
    {
        throw new System.NotImplementedException();
    }

    public void Exec()
    {
        _uiEditor.Deactive();
    }

}
