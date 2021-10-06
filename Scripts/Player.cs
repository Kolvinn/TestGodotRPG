using Godot;
using System;

public class Player : SuperPlayer
{
	private Resource arrow;

	private Storage inventory;


	public string action {
		get; set;
	}
	
	public string direction {
		get; set;
	}

	
	public override void _Ready(){
		base._Ready();
		arrow = ResourceLoader.Load("res://arrow.png");
		
	}
	public void _on_Player_input_event(Node viewport, InputEvent even, int shape_idx){
		GD.Print(viewport.ToString(), even.AsText(), shape_idx);
		if(even.IsPressed()){
			GD.Print("is pressed");
		}
	}
	// public void GetCurrentInventory(){

	// }

	// public void GetCurrentState(){

	// }

	public void _on_Player_mouse_entered(){
		//GD.Print("let's try this one instead");
		Input.SetCustomMouseCursor(arrow);
	}

	public void _on_Player_mouse_exited2(){
		Input.SetCustomMouseCursor(null);
	}
}
