using Godot;
using System;

public class Tree : StaticBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    private Sprite sprite;
    public override void _Ready()
    {
        sprite = GetChild<Sprite>(0);
    }


    public void _on_Area2D_mouse_entered(){
        GD.Print("hello?");
    }

    public void _on_Area2D_body_entered(){
        GD.Print("hello2?");
    }

    public void _on_Area2D_area_entered(){
        GD.Print("hello3?"); 
    }

    public void _on_Area2D_body_shape_entered(int body_id, Node body, int body_shape, int local_shape){
        GD.Print(body_id, body.ToString(), body_shape, local_shape); 
        //sprite.tras
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
