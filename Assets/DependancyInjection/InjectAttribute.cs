using System;
using UnityEngine;

// Exposes [inject] marker to set a class to inject a dependancy
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
public sealed class InjectAttribute : PropertyAttribute { }
