using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree{
    public abstract class Action : BehaviourBase
    {
        protected string _name;

        public string name{
            get{
                return _name;
            }
        }

        public void Create(string name){
            _name = name;
        }
    }
}

