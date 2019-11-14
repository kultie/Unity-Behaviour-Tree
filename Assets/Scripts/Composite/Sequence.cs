using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Kultie.BehaviourTree
{
    public class Sequence : Composite
    {
        public Sequence(string name, List<BehaviourBase> behaviours) : base(name, behaviours)
        {

        }

        public Sequence(string name, params BehaviourBase[] behaviours) : base(name, behaviours)
        {

        }

        public override Status Run(float dt, BehaviourContext context)
        {
            Status tmpStatus = behaviours[currentIndex].Update(dt, context);
            if (tmpStatus != Status.SUCCESS)
            {
                _status = tmpStatus;
                return _status;
            }
            currentIndex++;
            if (currentIndex == behaviours.Count)
            {
                _status = Status.SUCCESS;
            }
            return _status;
        }
    }
}

