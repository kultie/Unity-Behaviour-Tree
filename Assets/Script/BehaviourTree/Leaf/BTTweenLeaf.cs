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
            tween.OnUpdate(OnTweenUpdate).OnComplete(OnTweenComplete).OnKill(OnTweenKill).SetUpdate(UpdateType.Manual);
            condition = _condition;
            failOnInterupt = _failOnInterupt;
        }

        public override TreeNodeStatus Update(float dt)
        {
            if (condition != null)
            {
                if (condition())
                {
                    if (failOnInterupt)
                    {
                        tween.Kill();
                    }
                    else
                    {
                        tween.Pause();
                    }
                }
                else
                {
                    tween.Play();
                }
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

        void OnTweenKill()
        {
            tweenStatus = TreeNodeStatus.FAIL;
        }
    }
}


