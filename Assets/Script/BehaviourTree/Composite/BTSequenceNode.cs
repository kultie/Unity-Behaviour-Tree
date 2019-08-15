using System.Collections.Generic;
namespace Kultie.BTs
{
    public class BTSequenceNode : BTNode
    {
        List<BTNode> childNode;
        public BTSequenceNode(List<BTNode> child)
        {
            childNode = child;
        }

        public override TreeNodeStatus Run(float dt)
        {
            foreach (var node in childNode)
            {
                TreeNodeStatus childStatus = node.Update(dt);
                if (childStatus != TreeNodeStatus.SUCCESS)
                {
                    _nodeStatus = childStatus;
                    return _nodeStatus;
                }
            }
            _nodeStatus = TreeNodeStatus.SUCCESS;
            return _nodeStatus;
        }
    }
}

