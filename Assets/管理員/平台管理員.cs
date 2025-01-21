using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 平台管理員 
{
    public LayerMask 普通平台 = LayerMask.GetMask("地板") ;
    public bool 普通平台偵測(Transform 地面偵測器, float 範圍, LayerMask 平台)
    {
        Debug.Log("已觸發平台偵測");
        return Physics2D.OverlapCircle(地面偵測器.position, 範圍, 平台);
    }




    void Start()
    {
        Debug.Log(普通平台.value);
    }
}
