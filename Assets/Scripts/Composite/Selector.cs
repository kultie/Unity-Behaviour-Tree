using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree{
    public class Selector : BehaviourBase
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


        public Selector(string __name, List<BehaviourBase> _behaviours)
        {
            _name = __name;
            behaviours = _behaviours;
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            foreach (BehaviourBase behaviour in behaviours)
            {
                _status = behaviour.Update(dt, context);
                if (_status != Status.FAIL) return _status;
            }
            _status = Status.FAIL;
            return _status;
        }
    }
}


