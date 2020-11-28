using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeItem : MonoBehaviour
{
    public Node self;
    public void SetNode(Node node)
    {
        self = node;
    }

    private void OnMouseDown()
    {
        //角色移动
        if(self.isWall==false)
        {
            if(FlowManager.Instance.getTempFlow()==FlowManager.cFlow.choose)
            {
                if(Map.Instance.levelMoveNum>0)
                {
                    int max_x = Map.Instance.player_x + 1;
                    int min_x = Map.Instance.player_x - 1;
                    int max_y = Map.Instance.player_y + 1;
                    int min_y = Map.Instance.player_y - 1;
                    if (max_x > 9)
                        max_x = 9;
                    if (min_x < 0)
                        min_x = 0;
                    if (max_y > 9)
                        max_y = 9;
                    if (min_y < 0)
                        min_y = 0;

                    if(Map.Instance.player_x>=min_x&& Map.Instance.player_x <= max_x&& Map.Instance.player_y >= min_y&& Map.Instance.player_y <= max_y)
                    {
                        self.SetEndNode();
                        Map.Instance.levelMoveNum--;
                        GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);
                    }
                }                
            }            
        }      

        //点击荷花
        if(self.isFlower==true)
        {
            if (FlowManager.Instance.getTempFlow() == FlowManager.cFlow.choose)
            {
                if (Map.Instance.levelMoveNum > 0)
                {
                    //改变数值
                }
            }
        }
    }

    //光标变化
    private void OnMouseEnter()
    {
        if (self.isWall == false)
        {
            if (Mathf.Abs(self.X - Map.Instance.player_x) <= 1 && Mathf.Abs(self.Y - Map.Instance.player_y) <= 1)
            {
                
            }

        }

    }
}
