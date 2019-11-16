using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Kultie.BehaviourTree{
    public class Selector : Composite
    {

        public Selector(string name, List<BehaviourBase> behaviours) : base(name,behaviours)
        {

        }

        public Selector(string name, params BehaviourBase[] behaviours) : base(name, behaviours)
        {
  
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            Status tmpStatus = behaviours[currentIndex].Update(dt, context);
            if (tmpStatus != Status.FAIL)
            {
                _status = tmpStatus;
                return _status;
            }
            currentIndex++;
            if (currentIndex == behaviours.Count)
            {
                _status = Status.FAIL;
            }
            return _status;
        }
    }
}


