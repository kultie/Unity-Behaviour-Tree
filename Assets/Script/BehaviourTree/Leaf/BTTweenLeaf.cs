using DG.Tweening;
using UnityEngine;
namespace Kultie.BTs{
    public class BTTweenLeaf : BTNode
    {
        Tween tween;
        TweenLeafInterupCondition interupCondition;
        bool killOnInterupt;
        public BTTweenLeaf(Tween _tween, bool _killOnInterupt, TweenLeafInterupCondition _interuptCondition = null){
            tween = _tween;
            interupCondition = _interuptCondition;
            killOnInterupt = _killOnInterupt;
            tween.OnUpdate(OnUpdate).OnComplete(OnComplete);
        }

        public override TreeNodeStatus Update(float dt)
        {
            if(!tween.IsPlaying()){
                tween.Play();
            }
            if(tween.IsPlaying()){
                _nodeStatus = TreeNodeStatus.RUNNING;
                return _nodeStatus;
            }
            else{
                return _nodeStatus;
            }
        }

        public void OnComplete(){
            _nodeStatus = TreeNodeStatus.SUCCESS;
        }

        public void OnUpdate()
        {
            if(interupCondition()){
                if(killOnInterupt){
                    tween.Kill();  
                    _nodeStatus = TreeNodeStatus.FAIL;
                }
                else{
                    tween.Pause();
                    _nodeStatus = TreeNodeStatus.FAIL;
                }
            }
            else{
                if (!killOnInterupt)
                {
                    tween.Play();
                    _nodeStatus = TreeNodeStatus.RUNNING;
                }
            }
        }
    }
}

