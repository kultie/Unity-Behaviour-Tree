using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree
{
    public class RepeateUntilFail : Decorator
    {

        public RepeateUntilFail(BehaviourBase _behaviour)
        {
            Create("RepeateUntilFail", _behaviour);
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            Status st = behaviour.Update(dt, context);
            if (st != Status.FAIL)
            {
                st = Status.RUNNING;
            }
            else{
                st = Status.SUCCESS;
            }
            _status = st;
            return _status;
        }

		public override void Start(BehaviourContext context)
		{
            Debug.Log("Start " + name);
		}

        public override void Finish(Status _status, BehaviourContext context)
        {
            Debug.Log("Finish " + name + " Status: " + _status);
        }
	}
}
