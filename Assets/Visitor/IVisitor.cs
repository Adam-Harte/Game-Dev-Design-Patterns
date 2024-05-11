using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor
{
    // Visitor interface containing Visit methods with different arguments to determined what functionality to do
    // based on the Visitor argument e.g. add health if HealthComponent or add mana if ManaComponent
    public void Visit(HealthComponent healthComponent);
    public void Visit(ManaComponent manaComponent);
}
