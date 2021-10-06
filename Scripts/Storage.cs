using Godot;
using System;
using System.Collections;

public abstract class Storage : Godot.Control
{

    protected int capacity {get; set;}

    private ArrayList items;


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
      
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
    }

}
