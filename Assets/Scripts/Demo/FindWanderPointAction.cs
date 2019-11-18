using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
public class FindWanderPointAction : Action
{
    float x;
    float y;
    float radius;

    public FindWanderPointAction(float x, float y, float radius) : base("Finding Point")
    {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public override Status Run(float dt, BehaviourContext context)
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float distance = Random.Range(0, radius);

        WanderContext _context = (WanderContext)context;

        _context.moveToTarget = new Vector2(this.x + distance * Mathf.Cos(angle), this.y + distance * Mathf.Sin(angle));
        _status = Status.SUCCESS;
        return _status;
    }
}
