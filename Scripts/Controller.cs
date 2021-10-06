using Godot;
using System;

public class Controller : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	Button button;
	public override void _Ready()
	{
		button = new Button();
		//button.C
	}

	// public override void _Input(InputEvent inputEvent)
    // {
    //     GD.Print(inputEvent.AsText());
    // }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
