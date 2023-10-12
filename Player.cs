using Godot;
using System;

public partial class Player : Area2D
{
	[Export] public int Speed { get; set; } = 400;
	public Vector2 ScreenSize;

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta)
	{
		var movement = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("Move_Right"))
		{
			movement.X += 1;
		}

		if (Input.IsActionPressed("Move_Left"))
		{
			movement.X -= 1;
		}

		if (Input.IsActionPressed("Move_Down"))
		{
			movement.Y += 1;
		}

		if (Input.IsActionPressed("Move_Up"))
		{
			movement.Y -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (movement.X != 0 || movement.Y != 0)
		{
			movement = movement.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		Position += movement * (float)delta;
		Position = new Vector2(Mathf.Clamp(Position.X, 0, ScreenSize.X), Mathf.Clamp(Position.Y, 0, ScreenSize.Y));
	}	
}
