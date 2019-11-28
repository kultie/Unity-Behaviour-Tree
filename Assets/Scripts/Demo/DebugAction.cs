using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
public class DebugAction : Action
{
    string message;
    public DebugAction(string message) : base("Debug")
    {
        this.message = message;
    }

    public override Status Run(float dt, BehaviourContext context)
    {
        return Status.SUCCESS;
    }

    public override void Start(BehaviourContext context)
    {
        Debug.Log(message);
    }
}
