using System.Collections.Generic;
namespace Kultie.BTs
{
    public class BTSelectorNode : BTNode
    {
        List<BTNode> childNode;
        public BTSelectorNode(List<BTNode> child)
        {
            childNode = child;
        }

        public override TreeNodeStatus Run(float dt)
        {
            foreach (var node in childNode)
            {
                TreeNodeStatus childStatus = node.Update(dt);
                if (childStatus != TreeNodeStatus.FAIL)
                {
                    _nodeStatus = childStatus;
                    return _nodeStatus;
                }
            }
            _nodeStatus = TreeNodeStatus.FAIL;
            return _nodeStatus;
        }
    }
}