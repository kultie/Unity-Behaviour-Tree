using System.Collections.Generic;
namespace Kultie.BTs
{
    public class BTSequenceNode: BTNode
    {
        List<BTNode> childNode;
        BTNode currentNode;
        int currentIndex;
        public BTSequenceNode(List<BTNode> child){
            childNode = child;
            currentIndex = 0;
        }

        public override TreeNodeStatus Update(float dt)
        {
            if(currentIndex >= childNode.Count){
                _nodeStatus = TreeNodeStatus.SUCCESS;
                return _nodeStatus;
            }
            currentNode = childNode[currentIndex];
            _nodeStatus = currentNode.Update(dt);
            switch(_nodeStatus){
                case TreeNodeStatus.FAIL:
                    return _nodeStatus;
                case TreeNodeStatus.RUNNING:
                    return _nodeStatus;
                case TreeNodeStatus.SUCCESS:
                    currentIndex++;
                    _nodeStatus = TreeNodeStatus.RUNNING;
                    return _nodeStatus;
                default:
                    return _nodeStatus;
            }
        }
    }
}

