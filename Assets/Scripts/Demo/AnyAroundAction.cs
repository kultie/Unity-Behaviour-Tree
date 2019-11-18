using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
public class AnyAroundAction : Action
{
    string tag;
    float radius;
    public AnyAroundAction(string tag, float radius) : base("Any Around")
    {
        this.tag = tag;
        this.radius = radius;
    }

    public override Status Run(float dt, BehaviourContext context)
    {
        WanderContext _context = (WanderContext)context;
        Vector2 center = _context.go.transform.position;
        Collider2D[] entities = Physics2D.OverlapCircleAll(center, radius);
        if (entities.Length <= 1)
        {
            return Status.FAIL;
        }
        else {
            GameObject entity = entities[Random.Range(0, entities.Length)].gameObject;
            while (entity.Equals(_context.go)) {
                entity = entities[Random.Range(0, entities.Length)].gameObject;
            }
            _context.aroundGO = entity;
            _context.moveToTarget = _context.aroundGO.transform.position;
            return Status.SUCCESS;
        }
    }
}
