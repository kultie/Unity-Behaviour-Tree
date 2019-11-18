using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
public class MoveToPointAction : Action
{
    float speed = 5;
    public MoveToPointAction() : base("Move")
    {

    }

    public override Status Run(float dt, BehaviourContext context)
    {
        WanderContext _context = (WanderContext)context;
        GameObject obj = ((WanderContext)context).go;
        float distance = Vector2.Distance(obj.transform.position, _context.moveToTarget);
        if (distance < 0.1) {
            return Status.SUCCESS;
        }
        obj.transform.position = Vector2.MoveTowards(obj.transform.position, _context.moveToTarget, speed * dt);
        return Status.RUNNING;
    }
}
