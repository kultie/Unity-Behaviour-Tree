using System.Collections.Generic;
namespace Kultie.BTs
{
    public class BTParallelNode : BTNode
    {
        List<BTNode> childNode;
        List<BTNode> successNode = new List<BTNode>();
        BTNode currentNode;
        public BTParallelNode(List<BTNode> child)
        {
            childNode = child;
        }

        public override TreeNodeStatus Update(float dt)
        {
            bool haveRunningChild = false;
            successNode.Clear();
            foreach(var node in childNode){
                currentNode = node;
                TreeNodeStatus currentNodeStatus = currentNode.Update(dt);
                switch(currentNodeStatus){
                    case TreeNodeStatus.RUNNING:
                        _nodeStatus = TreeNodeStatus.RUNNING;
                        haveRunningChild = true;
                        continue;
                    case TreeNodeStatus.SUCCESS:
                        successNode.Add(node);
                        continue;
                    case TreeNodeStatus.FAIL:
                        continue;
                }               
            }
            _nodeStatus = haveRunningChild ? TreeNodeStatus.RUNNING : (successNode.Count == childNode.Count ? TreeNodeStatus.SUCCESS : TreeNodeStatus.FAIL);
            return _nodeStatus;
        }
    }
}