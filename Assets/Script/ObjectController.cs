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
    Tween tween;

    private void Start()
    {
        List<BTNode> nodes = new List<BTNode>();
        nodes.Add(BTLeafCreator.CreateConditionLeaf(true));
        nodes.Add(BTLeafCreator.CreateTweenLeaf(go.transform.DOMove(target.position, 5f), false, EvalData));
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
        return data > 10;
    }

}
