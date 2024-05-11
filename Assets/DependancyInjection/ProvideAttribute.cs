using System;
using UnityEngine;

// Exposes [provide] marker to set a class to provide a dependancy
[AttributeUsage(AttributeTargets.Method)]
public sealed class ProvideAttribute : PropertyAttribute { }
