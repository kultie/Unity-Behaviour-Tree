using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Kultie.BTs;
public class ObjectController : MonoBehaviour
{
    public GameObject go;
    public GameObject go2;
    public Transform target;
    BTSequenceNode sequenceNode;

    private void Start()
    {

        List<BTNode> nodes = new List<BTNode>();
        nodes.Add(BTLeafCreator.CreateTweenLeaf(go.transform.DOMove(target.position, 1f), null, true));
        //nodes.Add(BTDecoratorCreator.CreateRepeateUntil(BTLeafCreator.CreateTweenLeaf(go2.transform.DOMove(target.position, 1f), EvalData, true),TreeNodeStatus.SUCCESS));
        sequenceNode = new BTSequenceNode(nodes);
    }

    private void Update()
    {
        sequenceNode.Update(Time.deltaTime);
    }

    int data;
    bool EvalData()
    {
        data = Random.Range(0, 100);
        Debug.Log(data);
        return data < 90;
    }
}
