using Godot;
using System;

public partial class InteractRange : Area2D
{
	private Player player;
	private Interactable currentInteractable;

    public override void _Ready()
    {
        this.player = GetParent<Player>();
    }

    public override void _UnhandledInput(InputEvent @event)
    {
		if (this.currentInteractable == null)
		{
			return;
		}
        if (@event is InputEventKey inputEventKey)
		{
			if (inputEventKey.Pressed && inputEventKey.Keycode == Key.E)
			{
				this.currentInteractable.triggerEffect();
				this.currentInteractable.undoDetected();
				this.currentInteractable = null;
			}
		}
    }

    private void _OnBodyEntered(Node2D body)
	{
		if (body is Interactable interactable)
		{
			this.currentInteractable = interactable;
			this.currentInteractable.detected();
		}
	}

	private void _OnBodyExited(Node2D body)
	{
		if (this.currentInteractable == null)
		{
			return;
		}

		if (body is Interactable interactable)
		{
			this.currentInteractable.undoDetected();
			this.currentInteractable = null;
		}
	}
}
