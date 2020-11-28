﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Node curNode;
    public void SetCurNode(Node n)
    {
        curNode = n;
    }
    public Node GetCurNode()
    {
        return curNode;
    }

    Stack<Node> path = new Stack<Node>();
    public void MoveToEnd(Node n)
    {
        GetPath(n);

        Node p = path.Pop();
        StartCoroutine(MoveToNode(p));
        
    }

    void GetPath(Node n)
    {
        path.Push(n);
        if (n.parent != null)
        {
            GetPath(n.parent);
        }
    }

    void fun()
    {

    }
    void fun4()
    {
        Debug.Log("1");
    }

    IEnumerator MoveToNode(Node n)
    {
        transform.position = n.GetNodeItem().transform.position+new Vector3(0,0,-0.1f);
        yield return new WaitForSeconds(0.3f);
        curNode = n;
        n.ReSetNormalNode();

        if (path.Count > 0)
        {
            Node p = path.Pop();
            if(p != null)
                StartCoroutine(MoveToNode(p));
        }
    }

}
