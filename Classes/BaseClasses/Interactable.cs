using Godot;



public partial class Interactable: StaticBody2D
{
    public virtual void detected() {}
    public virtual void undoDetected() {}
    public virtual void triggerEffect() {}
}