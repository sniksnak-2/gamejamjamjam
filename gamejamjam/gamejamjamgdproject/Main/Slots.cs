using Godot;
using System;

public partial class Slots : Node2D
{

	[Export] public PackedScene SlotScene { get; set; }
	[Export] public Node2D SlotContainer { get; set; }

	[Export] public Vector2 OriginPos { get; set; }
	[Export] public float Gap { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{


		for(int i = 0; i <= 3; i++)
		{
			var instance = SlotScene.Instantiate<Node2D>();
			SlotContainer.AddChild(instance);
			instance.GlobalPosition = new Vector2(OriginPos.X + (Gap * i), OriginPos.Y);
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
