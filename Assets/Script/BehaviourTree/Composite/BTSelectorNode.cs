using System.Collections.Generic;
namespace Kultie.BTs{
    public class BTSelectorNode : BTNode
    {
        List<BTNode> childNode;
        BTNode currentNode;

        public BTSelectorNode(List<BTNode> child)
        {
            childNode = child;
        }

        public override TreeNodeStatus Update(float dt)
        {
            bool hasFinish = false;
            foreach (BTNode node in childNode)
            {
                currentNode = node;
                TreeNodeStatus status = currentNode.Update(dt);
                switch (status)
                {
                    case TreeNodeStatus.FAIL:
                        continue;
                    case TreeNodeStatus.SUCCESS:
                        _nodeStatus = TreeNodeStatus.SUCCESS;
                        return _nodeStatus;
                    case TreeNodeStatus.RUNNING:
                        hasFinish = false;
                        continue;
                    default:
                        continue;
                }
            }
            _nodeStatus = TreeNodeStatus.FAIL;
            return _nodeStatus;
        }
    }
}