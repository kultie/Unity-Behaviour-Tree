using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree
{
    public class Inverter : Decorator
    {
        public Inverter(BehaviourBase _behaviour)
        {
            Create("Inverter", _behaviour);
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            switch (behaviour.Update(dt,context))
            {
                case Status.FAIL:
                    _status = Status.SUCCESS;
                    break;
                case Status.SUCCESS:
                    _status = Status.FAIL;
                    break;
                case Status.RUNNING:
                    _status = Status.RUNNING;
                    break;
            }
            return _status;
        }

		public override void Finish(Status status, BehaviourContext context)
		{
            Debug.Log("Finish Inverter: " + _status);
		}
	}

}
