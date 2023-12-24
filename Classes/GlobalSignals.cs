using Godot;
using System;



public partial class GlobalSignals: Node
{
    [Signal]
    public delegate void moveRightEventHandler();

    [Signal]
    public delegate void moveLeftEventHandler();
}