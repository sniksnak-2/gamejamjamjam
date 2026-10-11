using Godot;
using System;
using System.Collections.Generic;

public partial class firstSrb : Node
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public void somethingelse()
    {
        GD.Print("test");
        slotsA ew = GetNode<slotsA>("../../SlotsA");
        ew.ListAdd("aple", 1);
        GD.Print("test");

    }
}
