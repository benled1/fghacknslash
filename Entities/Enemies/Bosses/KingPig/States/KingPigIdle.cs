using Godot;


public partial class KingPigIdle : State
{
    KingPig kingPig;

    public override void Init()
    {
        this.kingPig = this.fsm.GetParent<KingPig>();
    }
    public override void Enter() 
    {
        this.kingPig.animationPlayer.Play("Idle");
    }
}