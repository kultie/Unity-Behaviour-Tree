using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
using Kultie.TimerSystem;
public class WanderBTs : MonoBehaviour {
    Root root;
    WanderContext context;
    public GameObject obj;
    // Use this for initialization
    void Start() {
        context = new WanderContext {
            go = obj,
            timer = new Timer()
        };

        root = new Root(context, new Selector("idle",
                                             new Sequence("Change color",
                                                new DontSucceedInARow(new AnyAroundAction("Enemies", 1)),
                                                new MoveToPointAction(),
                                                new ChangeColorAction()
                                             ),
                                             new Sequence("wander",
                                                new FindWanderPointAction(obj.transform.position.x, obj.transform.position.y, 2),
                                                new MoveToPointAction(),
                                                new WaitAction(1)
                                             )
                                             ));

	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        context.timer.Update(dt);
        root.Update(dt, context);
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(obj.transform.position, 1);
    }
}

public class WanderContext : BehaviourContext {
    public Vector2 moveToTarget;
    public GameObject go;
    public Timer timer;
    public GameObject aroundGO;
}
