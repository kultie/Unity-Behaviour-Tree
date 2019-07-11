namespace Kultie.BTs{
    #region Enum
    public enum TreeNodeStatus { RUNNING, SUCCESS, FAIL }
    public enum ParallelPolicy { NONE, SEQUENCE, SELECTOR }
    public enum ConditionEvaluateOperator{GREATER, LESSER, GREATEROREQUAL, LESSEROROREQUAL, EQUAL}
    #endregion

    #region Delegate
    public delegate TreeNodeStatus NodeDelegate(float dt);
    public delegate bool TweenLeafInterupCondition();
    #endregion
}
