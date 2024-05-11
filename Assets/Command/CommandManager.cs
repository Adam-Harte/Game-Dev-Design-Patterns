using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Command pattern allows you to control the execution of commands/tasks/methods through an object containing a list of the commands to be executed
// This list allows you to hold the commands and then control when you want to execute them. For example execute commands after a certain time / chain commands together for combos.
// Also because the commands are held in a list you have the ability to implement undo and redo functionality
// This pattern lets you make commands preservable, interechangeable, undoable and redoable.
public class CommandManager : MonoBehaviour
{
    public ICommand singleCommand;
    public List<ICommand> commands = new List<ICommand>();

    public void Awake() {
        singleCommand = new AttackCommand();

        commands = new List<ICommand> {
            new AttackCommand(),
            new SpinCommand(),
        };
    }

    public void ExecuteCommands() {
        foreach (var command in commands) {
            command.Execute();
        }
    }

    public void ExecuteCommand() {
        singleCommand.Execute();
    }
}
