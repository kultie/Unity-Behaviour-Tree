namespace Kultie.BTs{
    #region Enum
    public enum TreeNodeStatus { RUNNING, SUCCESS, FAIL }
    public enum ParallelPolicy { NONE, SEQUENCE, SELECTOR }
    #endregion

    #region Delegate
    public delegate TreeNodeStatus NodeDelegate(float dt);
    #endregion
}
