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
        bool canmove = true;

        //Debug.Log("playerx: "+Map.Instance.player_x+" playery: "+ Map.Instance.player_y);
        //Debug.Log("nx: " + n.X + " ny: " + n.Y);

        if (path.Count == 0)
        {

            if (Mathf.Abs(n.X - Map.Instance.player_x) + Mathf.Abs(n.Y - Map.Instance.player_y) >= 2)
            {
                canmove = false;
                //path.Clear();
            }
            else
                canmove = true;

            Map.Instance.m_player.GetComponent<Animator>().SetBool("move", false);
            Map.Instance.CheckIsWin();
        }

        //动画朝向
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
        
        Map.Instance.m_player.GetComponent<Animator>().SetBool("move", true);

        if (canmove)
        {
            transform.DOMove(n.GetNodeItem().transform.position + new Vector3(0, 0, -0.1f), 0.5f);

            for (int i = 0; i < Map.Instance.deadPos.Count; i++)
            {
                if (n.X == Map.Instance.deadPos[i].x && n.Y == Map.Instance.deadPos[i].y)
                {
                    FlowManager.Instance.ChangeToDead();
                    Debug.Log(Map.Instance.GameObject_element[n.X, n.Y]);
                    Map.Instance.GameObject_element[n.X, n.Y].GetComponent<Animator>().SetTrigger("eat");
                    Map.Instance.m_player.transform.localScale = Vector3.zero;
                    yield return new WaitForSeconds(1.5f);
                    FlowManager.Instance.DeadFun();
                }
            }
            
            
            yield return new WaitForSeconds(0.5f);
            curNode = n;
            n.ReSetNormalNode();
        }
            
        //transform.position = n.GetNodeItem().transform.position+new Vector3(0,0,-0.1f);
        

        //Debug.Log(path.Count);

        if (path.Count > 0&&path.Count <= 4)
        {
            FlowManager.Instance.ChangeToMove();
            Node p = path.Pop();
            if(p != null)
            {
                Map.Instance.player_x = n.X;
                Map.Instance.player_y = n.Y;
                Map.Instance.SetPlayerPosition(n.X, n.Y);
                StartCoroutine(MoveToNode(p));
            }
                
        }
        if(path.Count>4)
        {
            path.Clear();
            FlowManager.Instance.ChangeToChoose();
            Map.Instance.m_player.GetComponent<Animator>().SetBool("move", false);
        }

        if (path.Count == 0)
        {
            StartCoroutine(ReturnToChoose());

            //Debug.Log(n.X + " +" + n.Y);
            //Debug.Log(transform.position.y + " +" + transform.position.y);

            if (canmove)
            {
                Map.Instance.player_x = n.X;
                Map.Instance.player_y = n.Y;
                Map.Instance.SetPlayerPosition(n.X, n.Y);
             }
          //  else
           // {
                //path.Clear();
           // }
            
            Map.Instance.m_player.GetComponent<Animator>().SetBool("move", false);
            Map.Instance.CheckIsWin();
        }

        //Debug.Log(Map.Instance.player_x);
        //Debug.Log(Map.Instance.player_y);
    }

    IEnumerator ReturnToChoose()
    {
        yield return new WaitForSeconds(0.4f);
        FlowManager.Instance.ChangeToChoose();
    }

}
