using System.Collections.Generic;
namespace Kultie.BTs
{
    public class BTParallelNode : BTNode
    {
        List<BTNode> childNode;
        int successCount;
        BTNode currentNode;
        ParallelPolicy policy = ParallelPolicy.NONE;

        public BTParallelNode(List<BTNode> _child)
        {
            childNode = _child;
        }

        public BTParallelNode(List<BTNode> _child, ParallelPolicy _policy)
        {
            childNode = _child;
            policy = _policy;
        }

        public override TreeNodeStatus Update(float dt)
        {
            bool haveRunningChild = false;
            successCount = 0;
            foreach (var node in childNode)
            {
                currentNode = node;
                TreeNodeStatus currentNodeStatus = currentNode.Update(dt);
                switch (currentNodeStatus)
                {
                    case TreeNodeStatus.RUNNING:
                        _nodeStatus = TreeNodeStatus.RUNNING;
                        haveRunningChild = true;
                        continue;
                    case TreeNodeStatus.SUCCESS:
                        if (policy == ParallelPolicy.SELECTOR)
                        {
                            _nodeStatus = currentNodeStatus;
                            return _nodeStatus;
                        }
                        successCount++;
                        continue;
                    case TreeNodeStatus.FAIL:
                        if (policy == ParallelPolicy.SEQUENCE)
                        {
                            _nodeStatus = currentNodeStatus;
                            return _nodeStatus;
                        }
                        continue;
                }
            }

            if (!haveRunningChild)
            {
                if (policy == ParallelPolicy.SELECTOR)
                {
                    if (successCount == childNode.Count)
                    {
                        _nodeStatus = TreeNodeStatus.FAIL;
                    }
                }
                if (policy == ParallelPolicy.SEQUENCE)
                {
                    if (successCount == childNode.Count)
                    {
                        _nodeStatus = TreeNodeStatus.SUCCESS;
                    }
                }
            }
            else
            {
                _nodeStatus = TreeNodeStatus.RUNNING;
            }
            return _nodeStatus;
        }
    }
}