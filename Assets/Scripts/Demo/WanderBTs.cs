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
                                             new Sequence("Change enemies color",
                                                FindAndMoveTo("Enemies", 1.5f),
                                                new ChangeColorAction(Color.red)
                                             ),
                                             new Sequence("Change friends color",
                                                FindAndMoveTo("Player", 1f),
                                                new ChangeColorAction(Color.blue)
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(obj.transform.position, 1.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(obj.transform.position, 1f);
    }

    Composite FindAndMoveTo(string key, float radius) {
        return new Sequence("Find And Move To",
                            new DontSucceedInARow(new AnyAroundAction(key, radius)),
                            new MoveToPointAction());
    }
}

public class WanderContext : BehaviourContext {
    public Vector2 moveToTarget;
    public GameObject go;
    public Timer timer;
    public GameObject aroundGO;
}
