using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BTs;
public class Controller : MonoBehaviour {
    BTSequenceNode testBT;
	// Use this for initialization
	void Start () {
        List<BTNode> leafs = new List<BTNode>();
        leafs.Add(BTLeafCreator.CreateConditionLeaf(Random.Range(0, 10) > 5));
        testBT = new BTSequenceNode(leafs);
	}
	
	// Update is called once per frame
	void Update () {
        testBT.Update(Time.deltaTime);
	}
}