namespace Kultie.BTs{
    #region Enum
    public enum TreeNodeStatus { RUNNING, SUCCESS, FAIL }
    #endregion

    #region Delegate
    public delegate TreeNodeStatus NodeDelegate();
    #endregion
}
