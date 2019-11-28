using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BehaviourTree
{
    public class Parallel : Composite
    {
        ParallelPocity successPolicy;
        ParallelPocity failurePolicy;

        public Parallel(string name, ParallelPocity successPolicy, ParallelPocity failurePolicy, List<BehaviourBase> behaviours) : base(name, behaviours)
        {
            this.successPolicy = successPolicy;
            this.failurePolicy = failurePolicy;
        }

        public Parallel(string name, ParallelPocity successPolicy, ParallelPocity failurePolicy, params BehaviourBase[] behaviours) : base(name, behaviours)
        {
            this.successPolicy = successPolicy;
            this.failurePolicy = failurePolicy;
        }

        public override Status Run(float dt, BehaviourContext context)
        {
            int successCount = 0, failureCount = 0;
            for (int i = 0; i < behaviours.Count; i++) {
                Status tmp = behaviours[i].Update(dt, context);
                if (tmp == Status.SUCCESS) {
                    successCount++;
                    behaviours[i].Finish(tmp,context);
                    if (successPolicy == ParallelPocity.ONE) {
                        _status = Status.SUCCESS;
                        return _status;
                    }
                }

                if (tmp == Status.FAIL) {
                    failureCount++;
                    behaviours[i].Finish(tmp, context);
                    if (failurePolicy == ParallelPocity.ONE) {
                        _status = Status.FAIL;
                        return _status;
                    }
                }
            }

            if (failurePolicy == ParallelPocity.ALL && failureCount == behaviours.Count) {
                _status = Status.FAIL;
                return _status;
            }
            if (successPolicy == ParallelPocity.ALL && successCount == behaviours.Count) {
                _status = Status.SUCCESS;
                return _status;
            }
            _status = Status.RUNNING;
            return _status;
        }

        public override void Finish(Status status, BehaviourContext context)
        {
            for (int i = 0; i < behaviours.Count; i++) {
                if (behaviours[i].status == Status.RUNNING) {
                    behaviours[i].Finish(status, context);
                }
            }
        }
    }
}