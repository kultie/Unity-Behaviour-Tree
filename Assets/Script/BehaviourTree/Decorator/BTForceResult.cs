namespace Kultie.BTs
{
    /// <summary>
    /// Use this decorator for force result status of a node for desired result.
    /// </summary>
    public class BTForceResult : BTNode
    {

        BTNode node;
        TreeNodeStatus desiredStatus;

        public BTForceResult(BTNode _node,TreeNodeStatus _desiredStatus)
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
            _nodeStatus = desiredStatus;
            return _nodeStatus;
        }
    }
}