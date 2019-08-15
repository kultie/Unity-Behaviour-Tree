namespace Kultie.BTs
{
    public class BTInverter : BTNode
    {

        BTNode node;
        public BTInverter(BTNode _node)
        {
            node = _node;
        }

        public override TreeNodeStatus Run(float dt)
        {
            switch (node.Update(dt))
            {
                case TreeNodeStatus.FAIL:
                    _nodeStatus = TreeNodeStatus.SUCCESS;
                    break;
                case TreeNodeStatus.SUCCESS:
                    _nodeStatus = TreeNodeStatus.FAIL;
                    break;
                case TreeNodeStatus.RUNNING:
                    _nodeStatus = TreeNodeStatus.RUNNING;
                    break;
            }
            return _nodeStatus;
        }
    }
}

