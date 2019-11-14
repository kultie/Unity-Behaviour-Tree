using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
public abstract class Composite : BehaviourBase {

    protected string name { get; private set; }

    protected List<BehaviourBase> behaviours { get; private set; }

    protected int currentIndex = 0;

    protected void Create(string name, List<BehaviourBase> behaviours)
    {
        this.name = name;
        this.behaviours = behaviours;
        currentIndex = 0;
    }

    protected void Create(string name, params BehaviourBase[] behaviours)
    {
        this.name = name;
        this.behaviours = behaviours.ToList();
        currentIndex = 0;
    }


    public override void Start(BehaviourContext context)
    {
        currentIndex = 0;
        Debug.Log("--------------------------------Start: " + name + "--------------------------------------");
    }

    public override void Finish(Status status, BehaviourContext context)
    {
        Debug.Log("--------------------------------Finish: " + name + " Status: " + _status + "--------------------------------------");
    }
}
