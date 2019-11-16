using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BehaviourTree;
public class WanderBTs : MonoBehaviour {
    Root root;
    WanderContext context;
    public GameObject obj;
    // Use this for initialization
    void Start() {
        context = new WanderContext {
            go = obj
        };

        root = new Root(context, new Sequence("Wander",
                                new FindWanderPointAction(obj.transform.position.x, obj.transform.position.y, 2, "Finding Point"),
                                new MoveToPointAction("Moving")));

	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        root.Update(dt, context);
	}
}

public class WanderContext : BehaviourContext {
    public Vector2 moveToTarget;
    public GameObject go;
}
