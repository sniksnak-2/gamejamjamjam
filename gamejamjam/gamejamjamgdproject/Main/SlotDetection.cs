using Godot;
using System;
using System.Collections.Generic;

public partial class SlotDetection : Node2D
{
	// Called when the node enters the scene tree for the first time.



	private List<Area2D> slots = new List<Area2D> 
	{

	};

	public override void _PhysicsProcess(double delta)
	{
		foreach (var slot in slots)
		{ 
			var bodies = slot.GetOverlappingBodies();
			GD.Print($"Objects in zone: {bodies.Count}");
		}
	}
	public override void _Ready()
	{
		foreach (Node child in GetNode("Triggers").GetChildren())
		{
			if (child is Area2D area) slots.Add(area);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
