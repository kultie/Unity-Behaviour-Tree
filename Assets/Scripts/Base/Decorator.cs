using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kultie.BehaviourTree
{
    public abstract class Decorator : BehaviourBase
    {
        protected string name { get; private set; }

        protected BehaviourBase behaviour { get; private set; }

        protected Decorator(string name, BehaviourBase behaviour)
        {
            this.name = name;
            this.behaviour = behaviour;
        }
    }
}
