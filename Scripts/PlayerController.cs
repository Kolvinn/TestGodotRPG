using Godot;
using System;
using System.Collections;

public class PlayerController : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    private Player player;
    private PlayerCamera2D camera;

    private TileMap tiles;

    private bool debug1 = true, debug2 = true;
    private enum GameState {
        Default,
        Menu,
        Esc

    }

    private static float maxSpeed = 300, friction = 2000, acceleration = 2000;
    private GameState gameState;
    private WorldObject obj;

    public Vector2 velocity = Vector2.Zero;
    private ArrayList currentActions = new ArrayList();

    private YSort sort;

    private string action = "Idle";

    private Droppable drop;

    private string savefile = "user://save.dat";

    private Godot.Control UI;

    private Godot.Control UIContainer;
    
    public override void _Ready()
    
    {   
        drop = new Droppable();
        gameState = GameState.Default;
        camera = GetChild<PlayerCamera2D>(0);
        tiles = GetChild<TileMap>(1);
        sort = GetChild<YSort>(2);
        player = sort.GetChild<Player>(1);
       // UIContainer = GetChild<Godot.Control>(3);
        //UIContainer.SetPosition(camera.Position);
        //UI.setSiz

        //var scene = GD.Load<PackedScene>("res://Scenes/UI/CharacterSheet.tscn");
        //UI = scene.Instance<Godot.Control>();
        //this.AddChild(UI);
        //UI.pos
        //this.UIContainer.Visible = false;
        
        //obj = GetChild<WorldObject>(3);
        //drop.PrintThings("");
        //var d  = Inst2Dict(this);
        //save();
        //Load();
        
    }

    private void save(){
        
        var file = new Godot.File();
        
        file.Open(this.savefile, File.ModeFlags.Write);

        foreach (object o in drop.GetPropertyList()){
            //Godot.Collections.Dictionary dic = (Godot.Collections.Dictionary) o;
            //GD.Print(dic.Keys);
        }
        file.StoreVar(drop, true);
        file.Close();
    }

    private bool Load(){
        var file = new Godot.File();
        if(file.FileExists(savefile)){
            file.Open(this.savefile, File.ModeFlags.Read);
            var obj = file.GetVar(true);
            //Node n = (Node) obj;
           // GD.Print("Has method 'PrintThings': ", n.HasMethod("PrintThings"));
            GD.Print(obj.ToString());
            file.Close();
            GD.Print(typeof(Player).IsInstanceOfType(obj));
        }
        else{
            GD.Print("could not find file");
        }
        
        return false;
    }

    // private void SetMovementAndAction(Vector2 velocity, Player player){
    //     //string action = "";

    //     //if we are idle, keep the last facing direction
    //     if(velocity == Vector2.Zero){
    //         player.action = "Idle";
    //         return;
    //     }
    //     string tempdirection = player.direction;
    //     player.action = "Walk";
    //     //if moving south
    //     if(velocity.y < 0){
    //         player.direction ="North";
    //     }
    //     else if (velocity.y >0){
    //         player.direction = "South";
    //     }
    //     //moving west. This will override north and south animations
    //     if (velocity.x < 0)
    //         player.direction = "West";
    //     else if (velocity.x > 0){
    //         player.direction = "East";
    //     }

    //     if(tempdirection != player.direction){
    //         //GD.Print(player.direction +"    "+tempdirection);
    //         //GD.Print(velocity);
    //     }
    // }

    public void GetMovementVector(float delta)
    {
        var speedCheck = Vector2.Zero;
        
        speedCheck.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        speedCheck.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
        speedCheck = speedCheck.Normalized();
        
        //if(speedCheck.x !=0 && speedCheck.x !=1 && speedCheck.y !=1 && speedCheck.y !=0)
           // GD.Print(speedCheck);
        
            
        
        if (speedCheck != Vector2.Zero){
            player.SetAnimation("parameters/Walk/blend_position", speedCheck);
            player.SetAnimation("parameters/Idle/blend_position", speedCheck);
            player.animationState.Travel("Walk");
            //velocity += speedCheck * delta * acceleration;
            //velocity = velocity.Clamped(maxSpeed * delta);
            velocity = velocity.MoveToward(speedCheck * maxSpeed, acceleration * delta);
        }
        else {
            
            
            player.animationState.Travel("Idle");
            velocity = velocity.MoveToward(Vector2.Zero, friction * (delta/2));
            //velocity = Vector2.Zero;
        }


        

        // GD.Print(Input.GetActionStrength("ui_right"));
        
        // GD.Print(Input.GetActionStrength("ui_left"));
        
        // GD.Print(Input.GetActionStrength("ui_up"));
        
        // GD.Print(Input.GetActionStrength("ui_down"));
        // if(Input.IsKeyPressed(((int)KeyList.Tab))){
        // }
        // if (Input.IsKeyPressed(((int)KeyList.D))){
        //     velocity.x += 1;
        //     currentActions.Add("WalkEast");
        //     action = "WalkEast";
        // }

        // if (Input.IsKeyPressed(((int)KeyList.A))){
        //     velocity.x -= 1;
        //     currentActions.Add("WalkWest");
        //     action = "WalkWest";
        // }

        // if (Input.IsKeyPressed(((int)KeyList.S))){
        //     velocity.y += 1;
        //     currentActions.Add("WalkSouth");
        //     action = "WalkSouth";
        // }

        // if (Input.IsKeyPressed(((int)KeyList.W))){
        //     velocity.y -= 1;
        //     currentActions.Add("WalkNorth");
        //     action = "WalkNorth";
        // }

        // if(currentActions.Count ==0 ){
        //     action = "Idle";
        // }

        // velocity = velocity * Settings.Speed;

        
    }
    // public override void _Input(InputEvent inputEvent)
    // {
    //     GD.Print(inputEvent.AsText());
    // }

    public override void _PhysicsProcess(float delta)
    { 

        if (this.gameState == GameState.Default){
            GetMovementVector(delta);

            GD.Print(this.velocity + "    "+this.player.animationState);
            //SetMovementAndAction(this.velocity, this.player);
           //GD.Print(velocity);
            //GD.Print(velocity);
           // GD.Print(player.animation);
            player.MoveAndSlide(this.velocity);




            //player.animationState.travel
            // obj.Rotation += (float)0.05;       
            //player.PlayAnimation(player.animation);

            //currentActions.length = 0 ? player.PlayAnimation("Idle") : player.PlayAnimation("WalkSouth");
            //currentActions.Clear();
            camera.Position = player.Position;
            //UIContainer.SetPosition(camera.Position);
        }
    }

    private void GetKeyInput(){
        //change game state to menu
        if(Input.IsKeyPressed(((int)KeyList.Tab))){
            //this.UIContainer.Visible = !this.UIContainer.Visible;
        }
        
            
    }
    public  override void _Process(float delta){
       GetKeyInput();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
