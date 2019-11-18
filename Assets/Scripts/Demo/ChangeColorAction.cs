using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
using Kultie.TimerSystem;
public class ChangeColorAction : Action
{
    bool done = false;
    public ChangeColorAction() : base("ChangeColor")
    {
        done = false;
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

        GameObject target = _context.aroundGO;
        SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();

        renderer.color = Color.blue;

        Timer timer = _context.timer;
        timer.After(2, () =>
        {
            renderer.color = Color.red;
            done = true;
        });
    }

    public override void Finish(Status status, BehaviourContext context)
    {
        done = false;
    }
}
