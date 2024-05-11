using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCommand : ICommand
{
    public void Execute() {
        Debug.Log("Spinning!");
    }
}
