using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kultie.BehaviourTree
{
    public abstract class Decorator : BehaviourBase
    {
        public string name { get; private set; }

        public BehaviourBase behaviour { get; private set; }

        public void Create(string __name, BehaviourBase _behaviour)
        {
            name = __name;
            behaviour = _behaviour;
        }
    }
}
