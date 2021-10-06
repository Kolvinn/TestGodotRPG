using Godot;
using System;

public class InventorySlot : Godot.TextureRect
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    private TextureRect icon;
    private Texture tempTex;

    private bool isDragging = false;

    private string texLoad = "res://Sprites/tree1.png";
    public override void _Ready()
    {
        icon = GetChild<TextureRect>(0);
        
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
    }
    public override object GetDragData(Vector2 position){
        isDragging = true;
        GD.Print("dragging?");
        if(icon ==null || icon.Texture == null)
            return null;
        
        //var data = 5;
        var dragTexture = new TextureRect();
        dragTexture.Expand = true;
        dragTexture.Texture = this.icon.Texture;
        dragTexture.RectSize = new Vector2(100,100);

        var control  = new Control();
        control.AddChild(dragTexture);
        dragTexture.RectPosition = new Vector2(-0.5f * dragTexture.RectSize.x,-0.5f * dragTexture.RectSize.y);
        SetDragPreview(control);

        this.tempTex = this.icon.Texture;
        this.icon.Texture = null;


        GD.Print("mouse pos: ",GetLocalMousePosition());
        GD.Print("drag pos: ",dragTexture.GetRect().Position);
        return this;
    }

    public TextureRect GetInvIcon(){
        return this.icon;
    }
    public override void DropData(Vector2 position, object data){

        InventorySlot incomingRect = new InventorySlot();
        incomingRect = (InventorySlot)data;

        //TextureRect incomingTexture = new TextureRect();
        //incomingTexture = (TextureRect)data;

        
        //InventorySlot dataRect = (InventorySlot)data;
        GD.Print("Incoming Texture: ", incomingRect.GetInvIcon().Texture);
        GD.Print("Dropped on texture: ", this.icon.Texture);

        Texture tex = ResourceLoader.Load(this.texLoad) as Texture;
        //Texture tex  = incomingTexture.Texture;

        //if this has a texture as well, then we want to swap them
        if(this.icon.Texture != null){
            GD.Print("swapsies");
            incomingRect.GetInvIcon().Texture = this.icon.Texture;

        }
        
        this.icon.Texture = tex;
        
        //this.icon.Texture = null;
    }

    public override void _UnhandledInput(InputEvent @event){
        // Input.ACtion
        // if(Input.IsActionJustReleased("Click")){
        //     GD.Print("released bby");
        // }
        if(this.isDragging && @event is InputEventMouseButton){
            InputEventMouseButton emb = (InputEventMouseButton)@event; 

            //if we released, then we can reset.
            if(!emb.Pressed){
                this.isDragging = false;
                this.icon.Texture = this.tempTex;
                //GD.Print(this.icon.Texture);
                //GD.Print(this.tempTex);
            }
            //if(emb.ButtonIndex == InputEventMouseButton.)
            //Input.IsActionJustReleased
            //GD.Print(@event);
        }
    }

    public override bool CanDropData(Vector2 position, object data) {
       // GD.Print(position, data);
        return true;
        
    }

            
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
