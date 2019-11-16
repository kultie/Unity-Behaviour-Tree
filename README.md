# Unity-Behaviour-Tree
Simple Behaviour Tree implementation for Unity c# base on article of [adnzzzzZ](https://github.com/adnzzzzZ/blog/issues/3)  

Added basic elements of BTs: Composite nodes (Sequence, Selector), Leaf and some Decorator(Inverter)
Feel free to use this for your Unity project.

# Namespace
Kultie.BehaviourTree

# Components
## Context
- All the data for the tree will contains in here.
- All node in the tree will use this as the intermediate to communicate with eachother
- Create your own Context and extending it with BehaviourContext class

## Root
- Root of the tree, these just a place holder and make sense for all you english speaker since tree start will composite node is not understandable
- Create Root using a context an a composite node

## Action Node
- Node that perform an action
- Create your own Action Node by extending Action class

## Composite Node
- Node that contains nodes, these node are the "direction" for the tree
- Create by list of nodes or using params in c#
- Create your own Composite Node by extending Composite class
- There are already built-in Sequence and Selector node


## Decorator Node
- Node that change the result of Action Node
- Create your own Decorator Node by extending Decorator class
- There are already built-in After, DontSucceddInARow, Inverter, RepeateUntilFail node

# How to Use
- Create how many nodes as you want
- Create a root
- Calling root.Update(dt, context) in the Update method of MonoBehavior
- Example: This will create a selector node and check for the random generator number
```
public class Controller : MonoBehaviour {

    Root behaviourTree;
    RandomContext context;
    Timer timer;
	void Start () {
        timer = new Timer();
        context = new RandomContext(6);
        //sequenceList.Add(new RandomNumber1(0,10));
        Selector sequence = new Selector("Selector check number",
            new After("Wait 2 second for random", 2, new RandomNumber1(0, 10), timer),
            new After("Wait 1 second for checking number", 1, new CheckNumber(), timer));
        behaviourTree = new Root(context, sequence);
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        behaviourTree.Update(dt, context);
        timer.Update(dt);
	}
}


public class RandomContext: BehaviourContext{
    public int targetNumber;
    public int currentNumber;
    public RandomContext(int _targetNumber){
        targetNumber = _targetNumber;
    }
}

public class RandomNumber1: Action{
    int min;
    int max;
    public RandomNumber1(int _min, int _max): base("Random number"){
        min = _min;
        max = _max;
    }

    public override Status Run(float dt, BehaviourContext context)
    {
        RandomContext tmpContext = (RandomContext)context;
        int currentValue = Random.Range(min, max);
        tmpContext.currentNumber = currentValue;
        _status = Status.FAIL;
        return _status;
    }

	public override void Start(BehaviourContext context)
	{
        RandomContext tmpContext = (RandomContext)context;
        Debug.Log("Target number is: " + tmpContext.targetNumber);
	}

	public override void Finish(Status status, BehaviourContext context)
	{
        RandomContext tmpContext = (RandomContext)context;
        Debug.Log("Status: " + _status);
        Debug.Log("Current number: " + tmpContext.currentNumber);
	}
}

public class CheckNumber : Action
{
    public CheckNumber(): base("Check Number"){
    }

    public override Status Run(float dt, BehaviourContext context)
    {
        RandomContext tmpContext = (RandomContext)context;
        if (tmpContext.currentNumber == tmpContext.targetNumber)
        {
            _status = Status.SUCCESS;
        }
        else
        {
            _status = Status.FAIL;
        }
        return _status;
    }

    public override void Start(BehaviourContext context)
    {
        RandomContext tmpContext = (RandomContext)context;
        Debug.Log(name +  "Target number is: " + tmpContext.targetNumber + "Current number: " + tmpContext.currentNumber);
    }

    public override void Finish(Status status, BehaviourContext context)
    {
        RandomContext tmpContext = (RandomContext)context;
        Debug.Log("Status: " + _status);
    }
}
```
