using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class 遊戲管理員 : MonoBehaviour
{
    public static 遊戲管理員 管理員;

    [Header("可選腳本")]
    public 主角藍圖[] 可選角色;
    public 武器[] 可選武器;


    /// <summary>
    /// 目前選擇到的角色
    /// </summary>
    public 角色控制 目前操作玩家;
    public 技能事件管理員 技能;
    public 平台管理員 平台;
    public 敵人AI管理員 敵人AI;
    public Transform 玩家位置;

    private void Awake()
    {
        // 確保單例的唯一性
        if (管理員 == null)
        {
            管理員 = this;
            DontDestroyOnLoad(gameObject); // 在場景之間保持不被銷毀
        }
        else
        {
            Destroy(gameObject); // 如果已經存在，則銷毀新的實例
        }
        技能 = new 技能事件管理員();
        敵人AI = new 敵人AI管理員();
        平台 = new 平台管理員();

        目前操作玩家.當前角色 = 可選角色[0];
        目前操作玩家.當前武器 = 可選武器[0];
    }

    public void 選擇角色(int y)
    {
        //FirstOrDefault 預設
        目前操作玩家.當前角色 = 可選角色.FirstOrDefault<主角藍圖>(x => x.角色id == y);
        Debug.Log("以切換" + 目前操作玩家.當前角色);
    }
    public void 選擇武器(int y)
    {
        //FirstOrDefault 預設
        目前操作玩家.當前武器 = 可選武器.FirstOrDefault<武器>(x => x.武器ID == y);
        Debug.Log("以切換" + 目前操作玩家.當前武器);
    }


}
