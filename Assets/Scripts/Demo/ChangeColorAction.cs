using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
using Kultie.TimerSystem;
public class ChangeColorAction : Action
{
    bool done = false;
    Color color;
    public ChangeColorAction(Color color) : base("ChangeColor")
    {
        done = false;
        this.color = color;
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
        Timer timer = _context.timer;

        GameObject _target = _context.aroundGO;

        SpriteRenderer renderer = _target.GetComponent<SpriteRenderer>();
        renderer.color = color;
        timer.After(2, () =>
        {
            renderer.color = Color.white;
            done = true;
        });
    }

    public override void Finish(Status status, BehaviourContext context)
    {
        done = false;
    }
}
