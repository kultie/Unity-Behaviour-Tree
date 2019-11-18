using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
public class AnyAroundAction : Action
{
    string tag;
    float radius;
    List<Collider2D> colliders = new List<Collider2D>();
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
            for (int i = 0; i < entities.Length; i++) {
                if (entities[i].gameObject.CompareTag(tag)) {
                    colliders.Add(entities[i]);
                }
            }
            if (colliders.Count > 0) {
                GameObject entity = colliders[Random.Range(0, colliders.Count)].gameObject;
                _context.aroundGO = entity;
                _context.moveToTarget = _context.aroundGO.transform.position;
                return Status.SUCCESS;
            }
            return Status.FAIL;
        }
    }

    public override void Start(BehaviourContext context)
    {
        colliders.Clear();
    }
}
