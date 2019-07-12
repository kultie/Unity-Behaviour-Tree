namespace Kultie.BTs
{
    /// <summary>
    /// Repeater decorator will run the task repeatly amount of times. Supported infinite run
    /// </summary>
    public class BTRepeater : BTNode
    {
        BTNode node;
        int time;
        int currentTime;
        /// <summary>
        /// Initializes a new instance of the Repeater Decorator. Input _time as 0 for infinite amount of running
        /// </summary>
        /// <param name="_node">Node.</param>
        /// <param name="_time">Time.</param>
        public BTRepeater(BTNode _node, int _time = 0)
        {
            node = _node;
            time = _time;
            if (time > 0)
            {
                currentTime = 0;
            }
            else
            {
                currentTime = -1;
            }
        }

        public override TreeNodeStatus Update(float dt)
        {
            _nodeStatus = node.Update(dt);
            if (time > 0 && _nodeStatus != TreeNodeStatus.RUNNING)
            {
                if (currentTime >= time)
                {
                    return _nodeStatus;
                }
                currentTime++;
            }
            _nodeStatus = TreeNodeStatus.RUNNING;
            return _nodeStatus;
        }
    }
}

