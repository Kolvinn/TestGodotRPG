using Godot;
using System;

public class WorldObject : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    private Area2D textureRect;
    public override void _Ready()
    {   
        textureRect = GetChild<Area2D>(1);
        textureRect.Connect("area_exited", this, "CheckPlease");
    }

    // public override void _Input(InputEvent inputEvent)
    // {
    //     GD.Print(inputEvent.AsText());
    // }

    public override void _Process(float delta){
        
    }

    public void CheckPlease(){

    }


    public void _on_TextureRect_mouse_entered(){

    }


    public void _on_TextureRect_mouse_exited(){

    }

    public  void _on_TextureRect_focus_entered(){

    }
}
