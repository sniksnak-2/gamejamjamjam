using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class SelectColumnScript : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
    List<Sprite2D> DeleteSprites = new List<Sprite2D> { };
    Godot.RandomNumberGenerator rng = new Godot.RandomNumberGenerator();
    List<string> slotOptions = new List<string> { "../SlotsA/aple", "../SlotsA/banaaa", "../SlotsA/grpaes", "../SlotsA/stawrbr" };
    List<Vector2> Positions = new List<Vector2> { new Vector2(295, 315), new Vector2(295, 395), new Vector2(295, 475), new Vector2(365, 315), new Vector2(365, 395), new Vector2(365, 475), new Vector2(445, 315), new Vector2(445, 395), new Vector2(445, 475) };
    Sprite2D Slot = null;
    List<string> SlotColumn1 = new List<string> { };
    List<string> SlotColumn2 = new List<string> { };
    List<string> SlotColumn3 = new List<string> { };

    public void StartPlacing()
    {
        foreach (Sprite2D sprite in DeleteSprites)
        {
            sprite.QueueFree();
        }
        DeleteSprites.Clear();
        int gambagambagambagamba = rng.RandiRange(0, slotOptions.Count - 1);
        Sprite2D original = GetNode<Sprite2D>(slotOptions[gambagambagambagamba]);
        Slot = (Sprite2D)original.Duplicate();
        Slot.Position = new Vector2 (250, 195);
        AddChild(Slot);
        GD.Print(Slot);
        DeleteSprites.Add(Slot);

    }
    public void PlaceAgain()
    {
        int gambagambagambagambagamba = rng.RandiRange(0, slotOptions.Count - 1);
        Sprite2D original = GetNode<Sprite2D>(slotOptions[gambagambagambagambagamba]);
        Slot = (Sprite2D)original.Duplicate();
        Slot.Position = new Vector2(250, 195);
        AddChild(Slot);
        GD.Print(Slot);
        DeleteSprites.Add(Slot);
    }
    public void Choose1()
    {
        if (SlotColumn1.Count < 3)
        {
            string SlotName = Slot.Name;
            SlotColumn1.Add(Slot.Name);
            GD.Print(Slot.Name);
            Slot.Position = Positions[3-SlotColumn1.Count];
            DeleteSprites.Add(Slot);
            if (SlotColumn1.Count + SlotColumn2.Count + SlotColumn3.Count < 9)
            {
                PlaceAgain();
            }
        }
    }
    public void Choose2()
    {
        if (SlotColumn2.Count < 3)
        {
            string SlotName = Slot.Name;
            SlotColumn2.Add(Slot.Name);
            GD.Print(Slot.Name);
            Slot.Position = Positions[6 - SlotColumn2.Count];
            DeleteSprites.Add(Slot);
            if (SlotColumn1.Count + SlotColumn2.Count + SlotColumn3.Count < 9)
            {
                PlaceAgain();
            }
        }
    }
    public void Choose3()
    {
        if (SlotColumn3.Count < 3)
        {
            string SlotName = Slot.Name;
            SlotColumn3.Add(Slot.Name);
            GD.Print(Slot.Name);
            Slot.Position = Positions[9 - SlotColumn3.Count];
            DeleteSprites.Add(Slot);
            if (SlotColumn1.Count + SlotColumn2.Count + SlotColumn3.Count < 9)
            {
                PlaceAgain();
            }
        }
    }
    public void skfjdhskdfjhskdfjhslkfjhslkfjhsdlkfjhslkfjhslkfjdhslkfjhslfkjh()
    {
        CombineSlots();
    }
    public List<string> CombineSlots()
    {
        List<string> CombinedSlots = new List<string>();

        foreach (string slot in SlotColumn1)
        {
            CombinedSlots.Add(slot.Split('/')[^1]);
        }

        foreach (string slot in SlotColumn2)
        {
            CombinedSlots.Add(slot.Split('/')[^1]);
        }

        foreach (string slot in SlotColumn3)
        {
            CombinedSlots.Add(slot.Split('/')[^1]);
        }
        slotsA ewier = GetNode<slotsA>("../SlotsA");
        ewier.ButtonHandler(CombinedSlots);
        Clear();
        GD.Print("coolnbameletsgo");
        return CombinedSlots;
    }
    public void Clear()
    {
        Slot.QueueFree();
        foreach (Sprite2D sprite in DeleteSprites)
        {
            sprite.QueueFree();
        }
        DeleteSprites.Clear();
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
