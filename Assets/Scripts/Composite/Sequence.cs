using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree{
    public class Sequence : BehaviourBase
    {
        string _name;

        public string name{
            get{
                return _name;
            }
        }

        List<BehaviourBase> behaviours;
     

        public Sequence(string __name, List<BehaviourBase> _behaviours){
            _name = __name;
            behaviours = _behaviours;
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            foreach(BehaviourBase behaviour in behaviours){
                _status = behaviour.Update(dt, context);
                if (_status != Status.SUCCESS) return _status;
            }
            _status = Status.SUCCESS;
            return _status;           
        }

		public override void Start(BehaviourContext context)
		{
            Debug.Log("Start: " + _name);
		}

        public override void Finish(Status _status,BehaviourContext context)
        {
            Debug.Log("Finish: " + _name +" Status: " + _status);
        }
	}
}

