namespace Kultie.BTs{
    public abstract class BTNode{
        public BTNode(){}

        protected TreeNodeStatus _nodeStatus;

        public TreeNodeStatus nodeStatus{
            get {
                return _nodeStatus;
            }
        }
        public abstract TreeNodeStatus Update(float dt);
    }
}