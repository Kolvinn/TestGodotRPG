using Godot;
using System;

public class PlayerCamera2D : Camera2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Player player;

    private float zoomspeed = 0.1f, upperLimit = 0.5f, lowerLimit = 1.5f, currentzoom = 1;

    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
    }

    public override void _Process(float delta){ 
        
    }

    public override void _UnhandledInput(InputEvent @event){
        if (@event is InputEventMouseButton){
            InputEventMouseButton emb = (InputEventMouseButton)@event;
            if (emb.IsPressed()){
                if (emb.ButtonIndex == (int)ButtonList.WheelUp && currentzoom >= upperLimit){
                    currentzoom -= zoomspeed;
                    this.Zoom = new Vector2(currentzoom,currentzoom);
                    GD.Print(currentzoom);
                }
                if (emb.ButtonIndex == (int)ButtonList.WheelDown && currentzoom < lowerLimit){
                    currentzoom += zoomspeed;
                    this.Zoom = new Vector2(currentzoom,currentzoom);
                    GD.Print(currentzoom);
                }
            }
        }
    
    }
}
