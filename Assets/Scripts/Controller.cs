﻿using System.Collections;
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
        List<BehaviourBase> sequenceList = new List<BehaviourBase>();
        context = new RandomContext(6);
        //sequenceList.Add(new RandomNumber1(0,10));
        sequenceList.Add(new After("Wait 2 second for random",2,new RandomNumber1(0, 10),timer));
        sequenceList.Add(new After("Wait 1 second for checking number", 1,new CheckNumber(),timer));
        Selector sequence = new Selector("Selector check number",sequenceList);
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

public class RandomNumber1: BehaviourActionBase{
    int min;
    int max;
    public RandomNumber1(int _min, int _max){
        Create("Random Number");
        min = _min;
        max = _max;
    }

    public override Status Run(float dt, BehaviourContext context)
    {
        RandomContext tmpContext = (RandomContext)context;
        int currentValue = Random.Range(min, max);
        tmpContext.currentNumber = currentValue;
        _status = Status.FAIL;
        //if(currentValue < 5){
        //    _status = Status.FAIL;
        //}
        //else{
        //    _status = Status.SUCCESS;
        //}
        return _status;
    }

	public override void Start(BehaviourContext context)
	{
        RandomContext tmpContext = (RandomContext)context;
        Debug.Log("Target number is: " + tmpContext.targetNumber);
	}

	public override void Finish(Status _status, BehaviourContext context)
	{
        RandomContext tmpContext = (RandomContext)context;
        Debug.Log("Status: " + _status);
        Debug.Log("Current number: " + tmpContext.currentNumber);
	}
}

public class CheckNumber : BehaviourActionBase
{
    public CheckNumber(){
        Create("Check Number");
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

    public override void Finish(Status _status, BehaviourContext context)
    {
        RandomContext tmpContext = (RandomContext)context;
        Debug.Log("Status: " + _status);
    }
}
