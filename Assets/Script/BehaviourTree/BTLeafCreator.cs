using DG.Tweening;
namespace Kultie.BTs
{
    public class BTLeafCreator
    {

        public static BTRepeater CreateRepeater(BTNode node, int time){
            return new BTRepeater(node, time);
        }

        public static BTLeaf CreateLeaf(NodeDelegate nodeDelegate)
        {
            return new BTLeaf(nodeDelegate);
        }

        public static BTConditionLeaf CreateConditionLeaf(bool val)
        {
            return new BTConditionLeaf(val);
        }

        public static BTTweenLeaf CreateTweenLeaf(Tween tween, TweenLeafInterupCondition interupCondition = null, bool killOnInterupt = false)
        {
            return new BTTweenLeaf(tween,interupCondition,killOnInterupt);
        }
    }
}

