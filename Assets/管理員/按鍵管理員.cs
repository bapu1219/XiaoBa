using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 這裡要寫按鍵的功能
/// </summary>
public class 按鍵管理員 : MonoBehaviour
{
    public static 按鍵管理員 管理員;
    public float 移動向量;

    public void 移動(InputAction.CallbackContext context)
    {
        移動向量 = context.ReadValue<Vector2>().x;
    }

    public void 跳躍(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)  // 只在按下時觸發
        {
        if (context.started)
            遊戲管理員.管理員.目前操作玩家.跳躍();
        }
    }

    public void 普通攻擊(InputAction.CallbackContext context)
    {
        
        
        if (context.phase == InputActionPhase.Started)  // 只在按下時觸發
        {
        Debug.Log("這是普攻");
        遊戲管理員.管理員.目前操作玩家.普攻();
        }

    }
    public void 技能1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        Debug.Log("這是技能1");
        StartCoroutine(遊戲管理員.管理員.目前操作玩家.當前武器.技能1());
    }

    public void 技能2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
        Debug.Log("這是技能2");
        StartCoroutine(遊戲管理員.管理員.目前操作玩家.當前武器.技能2());
        }
    }

    public void 互動(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        Debug.Log("這是互動");
    }

    void Update()
    {

    }
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
    }
}

