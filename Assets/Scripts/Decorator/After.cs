using UnityEngine;
using Kultie.TimerSystem;
namespace Kultie.BehaviourTree{
    public class After : Decorator
    {
        float duration;
        bool readyToRun;
        Timer timer;

        public After(string name, float duration, BehaviourBase behaviour, Timer timer) : base(name,behaviour){
            readyToRun = false;
            this.duration = duration;
            this.timer = timer;
        }

		public override Status Run(float dt, BehaviourContext context)
		{ 
            if(readyToRun){
                Status tmp = behaviour.Update(dt, context);
                _status = tmp;
            }
            else{
                _status = Status.RUNNING;
            }
            return _status;
		}

		public override void Start(BehaviourContext context)
		{
            Debug.Log("Starting After behaviour: " + name);
            readyToRun = false;
            timer.After(duration, () =>
            {
                readyToRun = true;
            },false,name);
		}

		public override void Finish(Status status, BehaviourContext context)
		{
            readyToRun = false;
            Debug.Log("Finishing After behaviour: " + name);
		}
	}
}

