using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kultie.BTs;
public class Controller : MonoBehaviour {
    BTRepeatUntil testBT;
	// Use this for initialization
	void Start () {
        List<BTNode> leafs = new List<BTNode>();
        leafs.Add(new BTLeaf(WalkToDoor));
        leafs.Add(OpenDoorSelector());
        leafs.Add(new BTLeaf(WalkThroughDoor));
        testBT = new BTRepeatUntil(new BTSequenceNode(leafs),TreeNodeStatus.SUCCESS);
	}
	
	// Update is called once per frame
	void Update () {
        if(testBT.nodeStatus == TreeNodeStatus.RUNNING){
            testBT.Update(Time.deltaTime);
        }
	}

    TreeNodeStatus WalkToDoor(){
        int rand = Random.Range(0, 100);
        Debug.Log(rand);
        if(rand > 50){
            return TreeNodeStatus.FAIL;
        }
        return TreeNodeStatus.SUCCESS;
    }

    BTSelectorNode OpenDoorSelector(){
        List<BTNode> selectorList = new List<BTNode>();
        selectorList.Add(new BTLeaf(OpenDoor));
        selectorList.Add(new BTLeaf(BreakDoor));
        BTSelectorNode selector = new BTSelectorNode(selectorList);
        return selector;
    }

    TreeNodeStatus OpenDoor(){
        int rand = Random.Range(0, 100);
        Debug.Log(rand);
        if (rand > 50)
        {
            Debug.Log("Fail to Open Door");
            return TreeNodeStatus.FAIL;
        }
        Debug.Log("Success to Open Door");
        return TreeNodeStatus.SUCCESS;
    }

    TreeNodeStatus BreakDoor()
    {
        Debug.Log("Break door");
        return TreeNodeStatus.SUCCESS;
    }

    TreeNodeStatus WalkThroughDoor()
    {
        Debug.Log("Walk through door");
        return TreeNodeStatus.SUCCESS;
    }

}