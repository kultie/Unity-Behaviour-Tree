namespace Kultie.BTs
{
    public abstract class BTNode
    {
        public BTNode() { }

        protected TreeNodeStatus _nodeStatus;

        public TreeNodeStatus nodeStatus
        {
            get
            {
                return _nodeStatus;
            }
        }
        public abstract TreeNodeStatus Run(float dt);

        public TreeNodeStatus Update(float dt){
            if (_nodeStatus == TreeNodeStatus.RUNNING || _nodeStatus == TreeNodeStatus.INIT)
            {
                if (nodeStatus == TreeNodeStatus.INIT)
                {
                    Start();
                }
                _nodeStatus = Run(dt);
                if (nodeStatus != TreeNodeStatus.RUNNING)
                {
                    Finish();
                }
            }
            return nodeStatus;
        }

        public virtual void Start(){
            
        }

        public virtual void Finish(){
            
        }
    }
}