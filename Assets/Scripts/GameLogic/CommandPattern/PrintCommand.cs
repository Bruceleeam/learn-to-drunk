using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCommand : ICommand
{
    private UIEditor _uiEditor;
    private string _text;

    public PrintCommand(UIEditor editor, string text)
    {
        _uiEditor = editor;
        _text = text;
    }

    public IEnumerator AsyncExec()
    {
        _uiEditor.SetText(_text);
        yield return new WaitForSeconds(3);
        _uiEditor.SetText("");
    }

    public void Exec()
    {
        _uiEditor.SetText(_text);
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }

}
