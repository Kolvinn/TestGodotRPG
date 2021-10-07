using Godot;
using System;

public class UIController : Godot.CanvasLayer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    private Godot.Control inventoryUI;
    public override void _Ready()
    {
        inventoryUI = GetChild<Godot.Control>(1);
        this.inventoryUI.Visible = false;
    }

    public void ToggleInventory(){
        this.inventoryUI.Visible= !this.inventoryUI.Visible;
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
