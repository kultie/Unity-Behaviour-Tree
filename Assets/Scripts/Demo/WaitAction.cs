using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
using Kultie.TimerSystem;
public class WaitAction : Action
{
    float duration;
    bool done = false;
    public WaitAction(float duration) : base("Wait")
    {
        this.duration = duration;
    }

    public override Status Run(float dt, BehaviourContext context)
    {
        if (done)
        {
            return Status.SUCCESS;
        }
        else {
            return Status.RUNNING;
        }
    }

    public override void Start(BehaviourContext context)
    {
        WanderContext _context = (WanderContext)context;
        _context.timer.After(duration,()=> {
            done = true;
        });
    }

    public override void Finish(Status status, BehaviourContext context)
    {
        done = false;
    }
}
