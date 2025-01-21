using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "隨機機率藍圖", menuName = "機率/隨機機率藍圖")]
public class 隨機機率藍圖 : ScriptableObject
{

    [Header("道具機率")]
    [Range(0, 100)] public int 道具_武器機率;
    [Range(0, 100)] public int 道具_遺物機率;
    [Range(0, 100)] public int 道具_裝備機率;
    [Range(0, 100)] public int 道具_金錢機率;

    [Header("稀有度機率")]
    [Range(0, 100)] public int 稀有度_普通機率;
    [Range(0, 100)] public int 稀有度_稀有機率;
    [Range(0, 100)] public int 稀有度_史詩機率;
    [Range(0, 100)] public int 稀有度_傳說機率;
    int 總和;
    [Header("是否出現")]
    public bool 是否出現武器;
    public bool 是否出現遺物;
    public bool 是否出現裝備;
    public bool 是否出現金錢;

    private void OnValidate()
    {
        int 稀有度機率總和 = 稀有度_普通機率 + 稀有度_稀有機率 + 稀有度_史詩機率 + 稀有度_傳說機率;
        if (稀有度機率總和 > 100)
        {
            稀有度修正機率();
        }

        int 道具機率總和 = 道具_武器機率 + 道具_遺物機率 + 道具_裝備機率 + 道具_金錢機率;
        if (道具機率總和 > 100)
        {
            道具修正機率();
        }
    }

    private void 稀有度修正機率()
    {
        int 超出量 = (稀有度_普通機率 + 稀有度_稀有機率 + 稀有度_史詩機率 + 稀有度_傳說機率) - 100;

        // 動態調整每個機率的比例
        if (稀有度_普通機率 > 0)
        {
            int 減少量 = Mathf.Min(稀有度_普通機率, 超出量);
            稀有度_普通機率 -= 減少量;
            超出量 -= 減少量;
        }
        if (稀有度_稀有機率 > 0 && 超出量 > 0)
        {
            int 減少量 = Mathf.Min(稀有度_稀有機率, 超出量);
            稀有度_稀有機率 -= 減少量;
            超出量 -= 減少量;
        }
        if (稀有度_史詩機率 > 0 && 超出量 > 0)
        {
            int 減少量 = Mathf.Min(稀有度_史詩機率, 超出量);
            稀有度_史詩機率 -= 減少量;
            超出量 -= 減少量;
        }
        if (稀有度_傳說機率 > 0 && 超出量 > 0)
        {
            int 減少量 = Mathf.Min(稀有度_傳說機率, 超出量);
            稀有度_傳說機率 -= 減少量;
            超出量 -= 減少量;
        }
    }
    private void 道具修正機率()
    {
        int 超出量 = (道具_武器機率 + 道具_遺物機率 + 道具_裝備機率 + 道具_金錢機率) - 100;

        // 動態調整每個機率的比例
        if (道具_武器機率 > 0)
        {
            int 減少量 = Mathf.Min(道具_武器機率, 超出量);
            道具_武器機率 -= 減少量;
            超出量 -= 減少量;
        }
        if (道具_遺物機率 > 0 && 超出量 > 0)
        {
            int 減少量 = Mathf.Min(道具_遺物機率, 超出量);
            道具_遺物機率 -= 減少量;
            超出量 -= 減少量;
        }
        if (道具_裝備機率 > 0 && 超出量 > 0)
        {
            int 減少量 = Mathf.Min(道具_裝備機率, 超出量);
            道具_裝備機率 -= 減少量;
            超出量 -= 減少量;
        }
        if (道具_金錢機率 > 0 && 超出量 > 0)
        {
            int 減少量 = Mathf.Min(道具_金錢機率, 超出量);
            道具_金錢機率 -= 減少量;
            超出量 -= 減少量;
        }
    }

}
