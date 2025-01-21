using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 角色控制 : MonoBehaviour
{
    [Header("主角動畫 & 行為")]
    private Rigidbody2D 主角;
    /// <summary>
    /// 控制主角動畫
    /// </summary>
    private Animator 動畫;

    [Header("被攻擊偵測")]
    private bool 是否被攻擊 = false;
    [Range(0, 100)] public int 擊退強度;


    [Header("攻擊偵測")]
    public Transform 攻擊範圍偵測器;
    public LayerMask 敵人圖層; //敵人目標圖層,檢查敵人
    [Range(0.01f, 2)] public float 攻擊範圍;
    public bool 攻擊判定 = false;
    public bool 是否在範圍;
    private bool 是否朝右 = false;
    Collider2D[] 被打到敵人;



    [Header("跳躍偵測")]
    public LayerMask 平台;
    // public LayerMask 可穿越平台;
    [Range(0.3f, 1)]
    public float 地面偵測器大小;
    /// <summary>
    /// 判斷是否著地(bool)
    /// </summary>
    bool 是否著地;
    int 跳躍次數;
    public Transform 地板觸碰;




    [Header("更變項目")]
    public 主角藍圖 當前角色;
    public 武器 當前武器;
    public 遺物藍圖[] 當前遺物;

    [Header("目前操作角色數值")]
    public int 目前魔力;
    public int 目前血量;


    void Start()
    {
        主角 = GetComponent<Rigidbody2D>();
        動畫 = GetComponent<Animator>();
        跳躍次數 = 當前角色.最大跳躍次數;
        初始化();
    }

    public void 移動()
    {
        主角.velocity = new Vector2(按鍵管理員.管理員.移動向量 * 當前角色.移動速度, 主角.velocity.y);

        動畫.SetBool("是否移動", 主角.velocity.x != 0);

        if (!是否朝右)
        {
            if (主角.velocity.x < 0)
            {
                // 主角圖片.flipX = 主角.velocity.x < 0;
                transform.Rotate(0, 180, 0);
                是否朝右 = true;
            }
        }
        else
        {
            if (主角.velocity.x > 0)
            {
                transform.Rotate(0, 180, 0);
                是否朝右 = false;
            }
        }
    }

    public void 普攻()
    {
        if (偵測是否攻擊成功())
        {
            StartCoroutine(遊戲管理員.管理員.目前操作玩家.當前武器.普攻());
            攻擊判定 = true;
            動畫.SetBool("是否攻擊", 攻擊判定);
        }
        else
        {
            Debug.Log("你沒打到敵人");
        }
    }

    public void 攻擊判定關閉()
    {
        攻擊判定 = false;
        Debug.Log("攻擊判定:" + 攻擊判定);
        動畫.SetBool("是否攻擊", 攻擊判定);
    }

    public void 初始化()
    {
        目前魔力 = 當前角色.基礎魔力值;
        目前血量 = 當前角色.最大生命值;
    }

    public void 跳躍()
    {
        if (跳躍次數 > 0)
        {
            主角.velocity = (Vector2.up * 當前角色.跳躍高度);
            跳躍次數 -= 1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //判斷是否被敵人觸碰
    {
        if (collision.gameObject.tag == "敵人")
        {
            Debug.Log("碰撞成功");
            目前血量 -= 10;
            

            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                主角.velocity = new Vector2(擊退強度, 擊退強度);
                是否被攻擊 = true; //左方碰撞
            }
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                主角.velocity = new Vector2(-擊退強度, 擊退強度);
                是否被攻擊 = true; //右方碰撞
            }
        }
    }

    public bool 偵測是否攻擊成功()
    {
        被打到敵人 = Physics2D.OverlapCircleAll(攻擊範圍偵測器.position, 攻擊範圍, 敵人圖層);
        if (被打到敵人 != null)
        {
            return true;
        }
        else
        {
            return true;
        }
    }





    public void 判斷是否著地()
    {
        是否著地 = Physics2D.OverlapCircle(地板觸碰.position, 地面偵測器大小, 平台);
        動畫.SetBool("是否跳躍", !是否著地);


        if (是否著地)
        {
            跳躍次數 = 當前角色.最大跳躍次數;
        }
    }




    private void OnDrawGizmos()
    {
        //DrawＷireSphere : 繪製空心圓，自帶兩個參數，分別為中心點跟半徑
        Gizmos.DrawWireSphere(地板觸碰.position, 地面偵測器大小);
        Gizmos.DrawWireSphere(攻擊範圍偵測器.position, 0.7f);
    }




    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!是否被攻擊)
        {
            移動();
        }
        if (是否被攻擊 == true)
        {
            if (Mathf.Abs(主角.velocity.x) < 0.1)
                是否被攻擊 = false;
        }
        判斷是否著地();
    }


}
