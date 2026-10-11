using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;
using static System.Reflection.Metadata.BlobBuilder;

public partial class Node2d : Node2D
{
    // Called when the node enters the scene tree for the first time.

    [Export] public slotsA TargetNode;
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
        List<string> slots_t = TargetNode.slots;
        slots_t.RemoveAt(0);
        slots_t.Add("aple");
    } 
}
