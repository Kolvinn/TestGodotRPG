using Godot;
using System;

public class TreeCollision : StaticBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_Area2D_body_entered(){
        GD.Print("let's see if this has actually worked, I doubt it has but I really hope that it actually has. Yay.");
    }

    public void _on_Area2D_body_entered2() {
        GD.Print("does this work?");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
