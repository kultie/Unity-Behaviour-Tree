using System;
namespace Kultie.BTs
{
    public class BTConditionLeaf : BTNode
    {
        bool val;
        public BTConditionLeaf(bool _val)
        {
            val = _val;
        }

        public override TreeNodeStatus Update(float dt)
        {
            return val ? TreeNodeStatus.SUCCESS : TreeNodeStatus.FAIL;
        }
    }
}

