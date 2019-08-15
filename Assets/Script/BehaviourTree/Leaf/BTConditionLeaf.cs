using System;
namespace Kultie.BTs
{
    public class BTConditionLeaf : BTNode
    {
        bool val;
        public BTConditionLeaf(bool _val)
        {
            val = _val;
        }

        public override TreeNodeStatus Run(float dt)
        {
            return val ? TreeNodeStatus.SUCCESS : TreeNodeStatus.FAIL;
        }

		public override void Start()
		{
            UnityEngine.Debug.Log("Start Leaf");
		}

        public override void Finish()
        {
            UnityEngine.Debug.Log("Finish Leaf");
        }
	}
}

