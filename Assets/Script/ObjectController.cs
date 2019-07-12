using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Kultie.BTs;
public class ObjectController : MonoBehaviour
{
    public GameObject go;
    public Transform target;
    BTSequenceNode sequenceNode;

    private void Start()
    {

        List<BTNode> nodes = new List<BTNode>();
        nodes.Add(BTLeafCreator.CreateTweenLeaf(go.transform.DOMove(target.position, 1f), EvalData, true));
        sequenceNode = new BTSequenceNode(nodes);
    }

    private void Update()
    {
        if (sequenceNode.nodeStatus == TreeNodeStatus.RUNNING)
        {
            sequenceNode.Update(Time.deltaTime);
        }
    }

    int data;
    bool EvalData()
    {
        data = Random.Range(0, 100);
        Debug.Log(data);
        return data > 90;
    }
}
