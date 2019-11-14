using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
using Kultie.TimerSystem;

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