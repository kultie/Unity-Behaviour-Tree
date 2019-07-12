using System;
using System.Collections.Generic;
using UnityEngine;
namespace Kultie.BTs
{
    public class BTLeaf : BTNode
    {
        public NodeDelegate action;

        public BTLeaf(NodeDelegate nodeDelegate)
        {
            action = nodeDelegate;
        }

        public override TreeNodeStatus Update(float dt)
        {
            _nodeStatus = action(dt);
            return _nodeStatus;
        }
    }
}

