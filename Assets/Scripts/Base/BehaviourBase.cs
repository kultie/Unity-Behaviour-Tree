using UnityEngine;

namespace Kultie.BehaviourTree
{
    public abstract class BehaviourBase
    {

        protected Status _status;

        public Status status
        {
            get
            {
                return _status;
            }
        }

        public BehaviourBase()
        {
            _status = Status.INVALID;
        }

        public Status Update(float dt, BehaviourContext context)
        {
            if (_status != Status.RUNNING)
            {
                Start(context);
            }
            _status = Run(dt, context);

            if (_status != Status.RUNNING)
            {
                Finish(_status, context);
            }
            return _status;

        }

        public virtual void Start(BehaviourContext context)
        {

        }


        public virtual void Finish(Status status, BehaviourContext context)
        {

        }

        public abstract Status Run(float dt, BehaviourContext context);
    }
}

