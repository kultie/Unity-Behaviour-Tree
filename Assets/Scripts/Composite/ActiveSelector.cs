using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree
{
    public class ActiveSelector : Composite
    {
        public ActiveSelector(string name, params BehaviourBase[] behaviours) : base(name, behaviours)
        {

        }

        public override Status Run(float dt, BehaviourContext context)
        {
            for (int i = 0; i < behaviours.Count; i++) {
                Status tmp = behaviours[i].Update(dt, context);
                if (tmp != Status.FAIL) {
                    _status = tmp;
                    return _status;
                }
            }
            _status = Status.FAIL;
            return _status;
        }
    }
}