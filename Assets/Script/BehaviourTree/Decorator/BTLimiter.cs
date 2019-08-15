namespace Kultie.BTs
{
    /// <summary>
    /// Limiter decorator will limit run time of a node for amount of frame
    /// </summary>
    public class BTLimiter : BTNode
    {
        BTNode node;
        int time;
        int currentTime;
        /// <summary>
        /// Initializes a new instance of the Limiter Decorator. After amount of frame tree node will have result fail
        /// </summary>
        /// <param name="_node">Node.</param>
        /// <param name="_time">Time.</param>
        public BTLimiter(BTNode _node, int _time)
        {
            node = _node;
            time = _time;
            currentTime = 0;
        }

        public override TreeNodeStatus Run(float dt)
        {
            if (currentTime >= time)
            {
                _nodeStatus = TreeNodeStatus.FAIL;
                return _nodeStatus;
            }
            _nodeStatus = node.Update(dt);
            if (_nodeStatus != TreeNodeStatus.RUNNING)
            {
                return _nodeStatus;
            }
            _nodeStatus = TreeNodeStatus.RUNNING;
            currentTime++;
            return _nodeStatus;
        }
    }
}

