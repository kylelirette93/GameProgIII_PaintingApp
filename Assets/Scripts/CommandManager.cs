using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public Stack<ICommand> undoStack = new Stack<ICommand>();
    public Stack<ICommand> redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();

        undoStack.Push(command);

        redoStack.Clear();
    }

    public void Undo()
    {
        if (undoStack.Count == 0) return;

        // Pop it off the top.
        ICommand command = undoStack.Pop();
        command.Undo();
        redoStack.Push(command);
        
    }

    public void Redo()
    {
        if (redoStack.Count == 0) return;

        ICommand command = redoStack.Pop();
        command.Execute();
        undoStack.Push(command);
    }
}
