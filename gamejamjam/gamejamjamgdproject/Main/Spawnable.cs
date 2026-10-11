using Godot;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;
using System.Collections.Generic;

public partial class Spawnable : Node2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] public int Variant = GD.RandRange(0, 3);

	private int prevVariant = 0;

	public override void _Process(double delta)
	{
		Sprite2D first = GetNode<Sprite2D>("RigidBody2D/sprites/first");
		Sprite2D second = GetNode<Sprite2D>("RigidBody2D/sprites/second");
		Sprite2D thrid = GetNode<Sprite2D>("RigidBody2D/sprites/third");
		Sprite2D fourth = GetNode<Sprite2D>("RigidBody2D/sprites/fourth");

		List<Sprite2D> sprite2Ds =
		[
			first, second, thrid, fourth
		];
		int i = 0;
		foreach(Sprite2D sprite in sprite2Ds)
		{
			sprite.Visible = (i == Variant);
			i++;
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.



}
