using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public Sequence(string name, List<BehaviourBase> behaviours)
        {
            _name = name;
            this.behaviours = behaviours;
            currentIndex = 0;
        }

        public Sequence(string name, params BehaviourBase[] behaviours)
        {
            _name = name;
            this.behaviours = behaviours.ToList();
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

