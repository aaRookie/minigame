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
        if(self.isWall==false)
        {
            if(FlowManager.Instance.getTempFlow()==FlowManager.cFlow.choose)
            {
                if(Map.Instance.levelMoveNum>0)
                if(Mathf.Abs(self.X-Map.Instance.player_x)<=1&& Mathf.Abs(self.Y - Map.Instance.player_y) <= 1)
                {
                    self.SetEndNode();
                    Map.Instance.levelMoveNum--;
                    GameUIManager.Instance.ChangeMoveNum(Map.Instance.levelMoveNum);
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
