using System;
using Godot;

public class Droppable : Node {

    private File Icon;
    
    private string item;

    public override void _Ready()
    {
        base._Ready();
    }

    public void SetString(string str){
        this.item = str;
    }

    public bool PrintThings(string item){
        string printable = string.IsNullOrEmpty(item) ? this.item: item;
        GD.Print(printable);
        return true;
    }

    public override Godot.Collections.Array _GetPropertyList()
    {   
        GD.Print(base._GetPropertyList());
       // foreach(object o in array){
           // GD.Print(o);
        //}
        return base._GetPropertyList();
    }
}