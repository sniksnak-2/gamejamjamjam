using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Godot;

public partial class ObjectSpawner : Node
{
	
	[Export] public PackedScene ObjectScene { get; set; }
	[Export] public Node2D ObjectsContainer { get; set; }
	[Export] public Node2D LaunchPoint { get; set; }
	[Export] public Vector2 InitialSpawnPosition { get; set; } = new Vector2(300, 300);
	[Export] public float forceMult = 1.3f;

	[Export] public Camera2D Camera { get; set; }

	private const double Interval = 0.1;
	private const float MaxExtension = 120f;
	private const float MaxChargeTime = 2.0f;
	private const float viewDuration = 5.0f;

	private Vector2 originPos = new Vector2(166.99f, 428.665f);
	private float radius = 150f;
	private float angle = 0f;
	private bool flipped = false;


	private bool pressedAlready = false;
	private double timeHeld = 0.0;
	private double timeToExtend = 0.2;
	private int thrownObjects = 0;
	private bool disableThrow = false;
	private double viewTimer = 0.0;


	private double _timer = 0.0;



	public override void _Ready()
	{
		GD.Print("ObjectSpawner is ready!");
		GD.Print($"Spawner path: {GetPath()}, ObjectScene: {ObjectScene?.ResourcePath ?? "null"}");
	}

	private float GetCharge()
	{
		if (timeHeld <= timeToExtend) return 0f;
		return Mathf.Clamp(((float)timeHeld - (float)timeToExtend) / MaxChargeTime, 0f, 1f);
	}

	public void ClearObjects()
	{
		if (ObjectsContainer == null) return;

		foreach (Node child in ObjectsContainer.GetChildren())
		{
			child.QueueFree();
		}
	}

	private void viewResults(double delta)
	{
		if (thrownObjects < 9) return;
		
		
		if(viewDuration < viewTimer)
		{
			disableThrow = false;
			thrownObjects = 0;
			Camera.Zoom = new Vector2(1f, 1f);
			viewTimer = 0;
			ClearObjects();

		}
		else
		{
			disableThrow = true;
			viewTimer = viewTimer + delta;
			Camera.Zoom = new Vector2(0.5f, 0.5f);

		}
	}

	public override void _Process(double delta)
	{
		_timer += delta;

		angle += (!flipped ? -1f : 1f) * (float)delta;
		float minAngle = 5.1f;
		float maxAngle = 6f;

		if (angle < minAngle)
		{
			angle = minAngle;
			flipped = true;
		}
		else if (angle > maxAngle)
		{
			angle = maxAngle;
			flipped = false;
		}

		float charge = GetCharge();
		float launchExtention = charge * MaxExtension;

		float x = (radius + launchExtention) * Mathf.Cos(angle);
		float y = (radius + launchExtention) * Mathf.Sin(angle);

		LaunchPoint.GlobalPosition = new Vector2(x, y) + originPos;

		_timer -= Interval;

		viewResults(delta);



		while (_timer >= Interval)
		{
		}

		if (Input.IsKeyPressed(Key.Space))
		{
			pressedAlready = true;
			timeHeld = timeHeld + delta;
		}
		else
		{
			pressedAlready = false;
			if (timeHeld > 0)
			{
				SpawnObject(originPos, LaunchPoint.GlobalPosition, GetCharge());
				timeHeld = 0;
			}
		}
	}

	public void SpawnObject(Vector2 position, Vector2 target, float charge)
	{
		if(disableThrow) { return; }
		if (ObjectsContainer == null)
		{
			GD.PrintErr("ObjectsContainer is not set!");
			return;
		}

		if (ObjectScene == null)
		{
			GD.PrintErr("ObjectScene is not set!");
			return;
		}

		var instance = ObjectScene.Instantiate<Node2D>();
		ObjectsContainer.AddChild(instance);
		instance.GlobalPosition = position;

		var body = instance.GetNode<RigidBody2D>("RigidBody2D");

		float minImpulse = 500f;
		float maxImpulse = 1200f;
		float impulse = Mathf.Lerp(minImpulse, maxImpulse, charge) * body.Mass * forceMult;

		Vector2 dir = (target - position).Normalized();
		thrownObjects = thrownObjects + 1;
		body.ApplyCentralImpulse(dir * impulse);
	}
}
