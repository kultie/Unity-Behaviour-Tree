using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree
{
    public class Sequence : BehaviourBase
    {
        string _name;

        public string name
        {
            get
            {
                return _name;
            }
        }

        List<BehaviourBase> behaviours;

        int currentIndex;

        public Sequence(string __name, List<BehaviourBase> _behaviours)
        {
            _name = __name;
            behaviours = _behaviours;
            currentIndex = 0;
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

        public override void Start(BehaviourContext context)
        {
            currentIndex = 0;
            Debug.Log("--------------------------------Start: " + _name + "--------------------------------------");
        }

        public override void Finish(Status _status, BehaviourContext context)
        {
            Debug.Log("--------------------------------Finish: " + _name + " Status: " + _status + "--------------------------------------");
        }
    }
}

