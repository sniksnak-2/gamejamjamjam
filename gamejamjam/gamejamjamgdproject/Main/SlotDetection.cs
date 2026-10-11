using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SlotDetection : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public List<string> moreSlots = new List<string> { "null", "null", "null", "null", "null", "null", "null", "null", "null" };

    private List<Area2D> slots = new List<Area2D> 
	{

	};

	public override void _PhysicsProcess(double delta)
	{
        moreSlots = new List<string> { "null", "null", "null", "null", "null", "null", "null", "null", "null" };
        int columnNum = 0;
		foreach (var column in slots)
		{
            var bodies = column.GetOverlappingBodies().OrderBy(b => -b.GlobalPosition.Y);

            List<Node2D> columnContent = new List<Node2D>();
			int i = 0;
			foreach (Node2D body in bodies)
			{
                var parent = body.GetParent<Spawnable>();   // typed parent
				int variant = parent.Variant;
                if (i >= 3) break;
                if (variant == 0)
				{
					moreSlots[(columnNum * 2) + i] = "aple";
                }
				else if (variant == 1)
				{
                    moreSlots[(columnNum * 2) + i] = "aple"; 
                }
				else if (variant == 2)
				{
                    moreSlots[(columnNum * 2) + i] = "banaaa";
                }
				else if (variant == 3)
				{
                    moreSlots[(columnNum * 2) + i] = "grpaes";
                }

				i++;
            }

			columnNum++;
		}
		GD.Print("1: " + moreSlots[0]);
		GD.Print("2: " + moreSlots[1]);
        GD.Print("3: " + moreSlots[2]);
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
