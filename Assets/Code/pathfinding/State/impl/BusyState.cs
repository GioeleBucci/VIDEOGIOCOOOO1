using UnityEngine;

public class BusyState : AbstractState
{
    private const float MIN_WAIT_TIME = 2f;
    private const float MAX_WAIT_TIME = 5f;
    private float timeLeft;

    public override void OnStateEnter(AbstractStateManager entity)
    {
        this.timeLeft = Random.Range(MIN_WAIT_TIME, MAX_WAIT_TIME);
    }

    public override void UpdateState(AbstractStateManager entity)
    {
        this.timeLeft -= Time.deltaTime;
        if (this.timeLeft <= 0)
        {
            entity.SwitchState(entity.WalkingState);
        }
    }
}