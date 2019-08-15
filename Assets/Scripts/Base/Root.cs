using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree
{
    public class Root : BehaviourBase
    {
        BehaviourContext context;
        BehaviourBase behaviour;

        public Root(BehaviourContext _context, BehaviourBase _behaviour)
        {
            context = _context;
            behaviour = _behaviour;
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            return behaviour.Update(dt, context);
        }

        public override void Start(BehaviourContext _context)
        {
            context = _context;
        }
    }

}
