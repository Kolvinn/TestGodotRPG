using Godot;
using System;

public class InventorySlot : Godot.TextureRect
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    private TextureRect icon;

    
    public Texture swappingTex{
        get;set;
    }

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
    


    public void LoadIcon(string resPath){
        this.texLoad = resPath;
        Texture tex = ResourceLoader.Load(this.texLoad) as Texture;
        this.icon.Texture = tex;
    }

    public void RemoveIcon(){
        this.texLoad = null;
        this.icon.Texture = null;
    }


    public override object GetDragData(Vector2 position){
        
        isDragging = true;
        GD.Print("dragging?");

        //if there's been no icon or icon texture loaded into inventory slot
        // don't drag anything
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

        //set the 
        this.swappingTex = this.icon.Texture;
        this.icon.Texture = null;


        GD.Print("mouse pos: ",GetLocalMousePosition());
        GD.Print("drag pos: ",dragTexture.GetRect().Position);
        GD.Print("Setting drag texture to: ",dragTexture);
        return this;
    }


    
    public override void DropData(Vector2 position, object data){

        //once in here there are 3 things we need to do.
        //1. Get the temp Texture load

        InventorySlot incomingRect = new InventorySlot();
        incomingRect = (InventorySlot)data;

        //1. Get the swappingTex from incoming texture because the actual icon tex is set to null
        Texture texToDrop = incomingRect.icon.Texture;
        //2. Get the texture of this current inventory slot to swap
        Texture texToSwap = this.icon.Texture;

        //3. If this texture is null, then we don't want to swap anything back
        // we don't have to worry about incoming textures being null!
        if(this.icon.Texture == null){
            
            LoadIcon(incomingRect.texLoad);
            incomingRect.RemoveIcon();
        }
        //if this texture isn't null, then just swap;
        else{
            string resPath = this.texLoad;
            LoadIcon(incomingRect.texLoad);
            incomingRect.LoadIcon(resPath);
        }
        


        // //TextureRect incomingTexture = new TextureRect();
        // //incomingTexture = (TextureRect)data;

        
        // //InventorySlot dataRect = (InventorySlot)data;
        // GD.Print("Incoming Texture: ", incomingRect.swappingTex);
        // GD.Print("Dropped on texture: ", this.icon.Texture);

        // Texture tex = ResourceLoader.Load(this.texLoad) as Texture;
        // //Texture tex  = incomingTexture.Texture;

        // //if this has a texture as well, then we want to swap them
        // if(this.icon.Texture != null){
        //     GD.Print("swapsies");
        //     //incomingRect.ic().Texture = this.icon.Texture;

        // }
        
        // this.icon.Texture = tex;
        
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
                this.icon.Texture = ResourceLoader.Load(this.texLoad) as Texture;
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
