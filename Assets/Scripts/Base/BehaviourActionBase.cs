using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree{
    public class BehaviourActionBase : BehaviourBase
    {
        protected string _name;

        public string name{
            get{
                return _name;
            }
        }

        public void Create(string __name){
            _name = __name;
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}

