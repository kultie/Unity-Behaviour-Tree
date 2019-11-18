using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree{
    public class DontSucceedInARow : Decorator
    {
        Status pastStatus;
        public DontSucceedInARow(BehaviourBase behaviour) : base("DontSucceedInARow", behaviour)
        {
            pastStatus = Status.INVALID;
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            Status st = behaviour.Update(dt, context);
            if(st == Status.SUCCESS && pastStatus == Status.SUCCESS){
                pastStatus = Status.FAIL;
                _status = Status.FAIL;
                return _status;
            }
            else
            {
                pastStatus = st;
                _status = st;
                return _status;
            }

        }

        public override void Start(BehaviourContext context)
        {

        }

        public override void Finish(Status status, BehaviourContext context)
        {

        }
    }
}