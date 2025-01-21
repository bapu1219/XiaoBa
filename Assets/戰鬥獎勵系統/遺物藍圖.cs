using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//
public class 遺物藍圖 : 物品藍圖
{

    //public string 名字;
    public string 效果描述;
    public Sprite 獎勵圖標;
    public GameObject 特效預製物件;

    // 自定義屬性：不同獎勵可以有不同的行為
    public enum 獎勵類型 {主動效果, 被動效果}
    public 獎勵類型 類型 ;
    public float 效果數值; // 效果值，例如傷害提升 10%，生命上限增加 20
    public float 持續時間; //效果持續多久?兩輪戰鬥?
    public string 獎勵目標; //角色身上的數值?


    
    
    




    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
