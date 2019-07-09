using System.Collections.Generic;
namespace Kultie.BTs
{
    public class BTSequenceNode: BTNode
    {
        List<BTNode> childNode;
        BTNode currentNode;

        public BTSequenceNode(List<BTNode> child){
            childNode = child;
        }

        public override TreeNodeStatus Update(float dt)
        {
            bool hasFinish = true;
            foreach(BTNode node in childNode){
                currentNode = node;
                TreeNodeStatus status = currentNode.Update(dt);
                switch (status)
                {
                    case TreeNodeStatus.FAIL:
                        _nodeStatus = TreeNodeStatus.FAIL;
                        return _nodeStatus;
                    case TreeNodeStatus.SUCCESS:
                        continue;
                    case TreeNodeStatus.RUNNING:
                        hasFinish = false;
                        continue;
                    default:
                        _nodeStatus = TreeNodeStatus.SUCCESS;
                        return _nodeStatus;
                }
            }
            _nodeStatus = hasFinish ? TreeNodeStatus.SUCCESS : TreeNodeStatus.RUNNING;
            return _nodeStatus;
        }
    }
}

