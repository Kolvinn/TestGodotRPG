using Godot;
using System;

public abstract class SuperPlayer : KinematicBody2D
{
	//private AnimatedSprite _animatedSprite;

	/**
	* set the wait delay on when the idle animation starts
	* in seconds
	*/
	private float animationDelay = 5;
	
	private AnimationPlayer animationPlayer;

	public AnimationTree animationTree
	{
		get; set;
	}



	public AnimationNodeStateMachinePlayback animationState;

	//private SceneTreeTimer currentTime = new SceneTreeTimer();
	public override void _Ready()
	{

		//_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		this.animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		this.animationTree = GetNode<AnimationTree>("AnimationTree");

		
		this.animationState = (AnimationNodeStateMachinePlayback)this.animationTree.Get("parameters/playback");
		//GD.Print(this.animationState.GetType());
		//GD.Print(typeof animationState);
	}

	public override void _Process(float delta)
	{
		
	}

	public virtual void SetAnimation(String param, Vector2 vector){
		//this.animationPlayer.Play(animation);
		this.animationTree.Set(param,vector);
	}
	protected void PrintSomeThings(string things){
		GD.Print(things);
	}

	// public void GetCurrentInventory(){

	// }

	// public void GetCurrentState(){

	// }
}
