namespace Kultie.BTs
{
    /// <summary>
    /// Repeat Until will run a task until desired result is achieved.
    /// </summary>
    public class BTRepeatUntil : BTNode
    {
        BTNode node;
        TreeNodeStatus desiredStatus;

        public BTRepeatUntil(BTNode _node, TreeNodeStatus _desiredStatus)
        {
            node = _node;
            desiredStatus = _desiredStatus;
        }

        public override TreeNodeStatus Update(float dt)
        {
            _nodeStatus = node.Update(dt);
            if(_nodeStatus == TreeNodeStatus.RUNNING){
                return _nodeStatus;
            }
            if(_nodeStatus != desiredStatus){
                _nodeStatus = TreeNodeStatus.RUNNING;
                return _nodeStatus;
            }
            return _nodeStatus;
            
        }
    }
}
