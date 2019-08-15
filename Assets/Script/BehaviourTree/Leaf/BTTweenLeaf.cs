using UnityEngine;
using DG.Tweening;
namespace Kultie.BTs
{
    public class BTTweenLeaf : BTNode
    {
        Tween tween;
        TreeNodeStatus tweenStatus;
        bool failOnInterupt;
        TweenLeafInterupCondition condition;
        public BTTweenLeaf(Tween _tween, TweenLeafInterupCondition _condition = null, bool _failOnInterupt = false)
        {
            tween = _tween;
            tweenStatus = TreeNodeStatus.INIT;
            tween.OnUpdate(OnTweenUpdate).OnComplete(OnTweenComplete).SetUpdate(UpdateType.Manual);
            condition = _condition;
            failOnInterupt = _failOnInterupt;
        }

        public override TreeNodeStatus Run(float dt)
        {
            if (condition != null)
            {
                if (condition() && !tween.IsComplete())
                {
                    tween.Pause();
                    if (failOnInterupt)
                    {
                        tweenStatus = TreeNodeStatus.FAIL;
                    }
                }
                else
                {
                    tween.Play();
                }
            }
            else
            {
                tween.Play();
            }
            DOTween.ManualUpdate(dt, 0);
            return tweenStatus;
        }

        void OnTweenComplete()
        {
            tweenStatus = TreeNodeStatus.SUCCESS;
        }

        void OnTweenUpdate()
        {
            tweenStatus = TreeNodeStatus.RUNNING;
        }

		public override void Start()
		{
            Debug.Log("Start tween leaf");
		}

        public override void Finish()
        {
            Debug.Log("Finish tween leaf");
        }
	}
}


