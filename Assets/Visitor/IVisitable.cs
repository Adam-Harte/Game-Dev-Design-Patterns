using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitable
{
    // interface for accepting a Visitor to then later have some functionality excecuted
    public void Accept(IVisitor visitor);
}
