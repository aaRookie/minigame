using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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

    public Stack<Node> path = new Stack<Node>();
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


    IEnumerator MoveToNode(Node n)
    {
        if (n.GetNodeItem().transform.position.y < transform.position.y)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else if (n.GetNodeItem().transform.position.y > transform.position.y)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (n.GetNodeItem().transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (n.GetNodeItem().transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }

        transform.DOMove(n.GetNodeItem().transform.position + new Vector3(0, 0, -0.1f),0.5f);
        //transform.position = n.GetNodeItem().transform.position+new Vector3(0,0,-0.1f);
        yield return new WaitForSeconds(0.5f);
        curNode = n;
        n.ReSetNormalNode();

        if (path.Count > 0&&path.Count <= 4)
        {
            FlowManager.Instance.ChangeToMove();
            Node p = path.Pop();
            if(p != null)
                StartCoroutine(MoveToNode(p));
        }
        if(path.Count>4)
        {
            path.Clear();
            FlowManager.Instance.ChangeToChoose();
        }

        if (path.Count == 0)
        {
            StartCoroutine(ReturnToChoose());
            Map.Instance.player_x = n.X;
            Map.Instance.player_y = n.Y;
            Map.Instance.SetPlayerPosition(n.X, n.Y);
            Map.Instance.CheckIsWin();
        }
    }

    IEnumerator ReturnToChoose()
    {
        yield return new WaitForSeconds(0.4f);
        FlowManager.Instance.ChangeToChoose();
    }

}
