﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int X;
    public int Y;
    public float F = 0;
    public float G = 0;
    public float H = 0;

    public nodetype temptype;
    public enum nodetype
    {
        flower,
        box,
        tree,
        danger,
        ext,
        zero,
        stop,
    }

    //石头
    public bool isWall=false;
    //荷花
    public bool isFlower = false;
    //box
    public bool isBox=false;
    //藤蔓
    public bool isTree = false;
    //镜子
    public bool isMirror = false;
    //危险
    public bool isDanger = false;
    //终点
    public bool isEnd = false;

    public bool FlowerSwitch = false;
    public bool TreeSwitch = false;
    public bool MirrorSwitch = false;
    public bool BoxSwitch = false;

    public Node parent;
    public Map map;
    private Renderer nodeRender;
    private NodeItem nodeItem;

    public int ChangeDir = 0;
    public int ChangeX = 0;
    public int ChangeY = 0;


    public Node(int x, int y, Node parent = null)
    {
        this.X = x;
        this.Y = y;
        if (parent != null)
        {
            this.parent = parent;
        }
        CreateNode();
    }

    public void SetType()
    {
        if (temptype == nodetype.tree)
        {
            SetIsTree(isTree);
        }
        else if (temptype == nodetype.box)
        {
            SetIsBox(isBox);
        }
        else if (temptype == nodetype.danger)
        {
            SetIsDanger(isDanger);
        }
            //SetIsDanger(isDanger);
        else if (temptype == nodetype.flower)
        {
            SetIsFlower(isFlower);
        }
            //SetIsFlower(isFlower);
    }

    //设置墙
    public void SetIsWall(bool wall)
    {
        isWall = wall;
        if (isWall)
            temptype = nodetype.zero;
        //if(isWall)
            //temptype = nodetype.wall;
        //else
            //temptype = nodetype.space;

        //if (isWall) { nodeRender.material.SetColor("_Color", Color.black); }
    }

    public void ChangeToWall(bool wall)
    {
        isWall = wall;
    }

    //设置荷花
    public void SetIsFlower(bool flower)
    {
        isFlower = flower;
        temptype = nodetype.flower;
        //if (isFlower) 
            //temptype
        //{ nodeRender.material.SetColor("_Color", Color.blue); }
    }

    //设置藤蔓
    public void SetIsTree(bool tree)
    {
        isTree = tree;
        temptype = nodetype.tree;
        //TreeSwitch = true;
        //if (isTree) { nodeRender.material.SetColor("_Color", Color.green); }
    }  
    
    //box
    public void SetIsBox(bool box)
    {
        isBox = box;
        temptype = nodetype.box;
        ChangeToWall(isBox);
        //if(isBox)
        //    temptype = nodetype.box;
        //else
        //    temptype = nodetype.box;
        //if (isBox) { nodeRender.material.SetColor("_Color", Color.yellow); }
    }

    public void SetIsDanger(bool danger)
    {
        isDanger = danger;
    }

    //设置镜子
    public void SetIsMirror(bool mirror)
    {
        isMirror = mirror;
        if (isMirror) { nodeRender.material.SetColor("_Color", Color.green); }
    }

    public void SetParent(Node p)
    {
        this.parent = p;
    }

    public void UpdateParentAndG(Node p, float G)
    {
        this.parent = p;
        this.G = G;
        this.F = this.G + H;
    }
    void CreateNode()
    {
        GameObject node = GameObject.Instantiate(Resources.Load("grid"), GameObject.Find("Map").transform) as GameObject;
        node.transform.position = new Vector3(this.Y + 0.5f, 9.5f-this.X, 0f);
        //Debug.Log(node.transform.position);

        node.transform.name = "Node(" + X + "," + Y + ")";
        nodeRender = node.GetComponent<Renderer>();

        nodeItem = node.GetComponent<NodeItem>();
        nodeItem.SetNode(this);
    }

    public void ShowPathNode()
    {
        nodeRender.material.SetColor("_Color", Color.green);
        if (parent != null)
        {
            parent.ShowPathNode();
        }
    }

    public void ReSetNode()
    {
        F = 0;
        G = 0;
        H = 0;
        isWall = false;
        parent = null;
        nodeRender.material.SetColor("_Color", Color.white);
    }

    public void ReSetNormalNode()
    {
        F = 0;
        G = 0;
        H = 0;
        parent = null;
        if(!isWall)
            nodeRender.material.SetColor("_Color", Color.white);
    }


    public void SetMap(Map m)
    {
        map = m;
    }
    public void SetEndNode()
    {
        map.ReFind();
        map.StartFindPath(map.player.GetCurNode(), this);
    }

    public NodeItem GetNodeItem()
    {
        return nodeItem;
    }
}
