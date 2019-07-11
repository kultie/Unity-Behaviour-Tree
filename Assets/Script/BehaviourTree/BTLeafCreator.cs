using DG.Tweening;
namespace Kultie.BTs{
    public class BTLeafCreator
    {
        public static BTLeaf CreateLeaf(NodeDelegate nodeDelegate){
            return new BTLeaf(nodeDelegate);
        }

        public static BTConditionLeaf CreateConditionLeaf(bool val){
            return new BTConditionLeaf(val);
        }

        public static BTTweenLeaf CreateTweenLeaf(Tween tween, bool killOnInterupt, TweenLeafInterupCondition interupCondition = null){
            return new BTTweenLeaf(tween,killOnInterupt,interupCondition);
        }
    }
}

