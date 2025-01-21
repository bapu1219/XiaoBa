// using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using HutongGames.PlayMaker;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI管理員 : MonoBehaviour
{
    // Start is called before the first frame update


    public static UI管理員 管理員;
    public Image 頭像; //場上的ui

    public Slider 血量條;
    public Slider 魔力條;

    public GameObject 獎勵選擇介面;

    public TextMeshProUGUI 除錯訊息;
    [Header("三選一抽取")]
    public 遺物藍圖[] 獎勵池;
    public TextMeshProUGUI[] 名字框;
    public 隨機機率藍圖 當前機率;


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

    void Start()
    {
        更新當前頭像();
        更新當前角色血量法力上限();
        // StartCoroutine(獎勵選擇());
    }

    // Update is called once per frame
    void Update()
    {
        更新角色血量法力();
    }

    void 更新當前頭像()
    {
        頭像.sprite = 遊戲管理員.管理員.目前操作玩家.當前角色.證件照; //同步角色的頭像給ui
    }

    void 更新角色血量法力()
    {
        血量條.value = 遊戲管理員.管理員.目前操作玩家.目前血量;
        魔力條.value = 遊戲管理員.管理員.目前操作玩家.目前魔力;
    }
    public void 更新當前角色血量法力上限()
    {
        血量條.maxValue = 遊戲管理員.管理員.目前操作玩家.當前角色.最大生命值;
        魔力條.maxValue = 遊戲管理員.管理員.目前操作玩家.當前角色.基礎魔力值;
    }

    /// <summary>
    /// 彈出獎勵選擇視窗
    /// </summary>
    /// <returns></returns>
    public IEnumerator 獎勵選擇()
    {
        yield return new WaitForSeconds(3); //等3秒
        獎勵選擇介面.SetActive(true);
        除錯訊息.text = "pass";
        yield return new WaitForSeconds(3);
        獎勵選擇介面.SetActive(false);
    }
    private int[] 以選擇數字;
    public void 三選一抽取()
    {
        int 隨機;
        以選擇數字 = new int[3];

        for (int i = 0; i < 3; i++)
        {
            do
            {
                隨機 = Random.Range(0, 獎勵池.Length);

            }
            while (System.Array.IndexOf(以選擇數字, 隨機) != -1);

            以選擇數字[i] = 隨機;
            Debug.Log(獎勵池[以選擇數字[i]].名稱);
        }

        for (int i = 0; i < 3; i++)
        {
            名字框[i].text = 獎勵池[以選擇數字[i]].名稱;
        }
        獎勵選擇介面.SetActive(true);
    }
    public void 選擇遺物(int 所選)
    {
        // 判斷玩家身上的遺物欄是否還有空位
        if (遊戲管理員.管理員.目前操作玩家.當前遺物.Length == 0)
        {
            遊戲管理員.管理員.目前操作玩家.當前遺物 = new 遺物藍圖[] { 獎勵池[以選擇數字[所選]] };
        }


        else
        {
            遺物藍圖[] 新當前遺物 = new 遺物藍圖[遊戲管理員.管理員.目前操作玩家.當前遺物.Length + 1];
            for (int i = 0; i < 遊戲管理員.管理員.目前操作玩家.當前遺物.Length; i++)
            {
                新當前遺物[i] = 遊戲管理員.管理員.目前操作玩家.當前遺物[i];
            }
            新當前遺物[遊戲管理員.管理員.目前操作玩家.當前遺物.Length] = 獎勵池[以選擇數字[所選]];
            遊戲管理員.管理員.目前操作玩家.當前遺物 = 新當前遺物;

        }
    }
    public 遺物藍圖[] 判斷稀有度()
    {
        遺物藍圖[] 稀有度裡有的物品;
        
        int 隨機到的稀有度 = Random.Range(0, 101);
        if (隨機到的稀有度 < 當前機率.稀有度_傳說機率)
        {
            稀有度裡有的物品 = 獎勵池.Where(獎勵 => 獎勵.稀有度等級 == 物品藍圖.稀有度.傳奇).ToArray();
        }
        else if (隨機到的稀有度 < 當前機率.稀有度_史詩機率)
        {
            稀有度裡有的物品 = 獎勵池.Where(獎勵 => 獎勵.稀有度等級 == 物品藍圖.稀有度.史詩).ToArray();
        }
        else if (隨機到的稀有度 < 當前機率.稀有度_稀有機率)
        {
            稀有度裡有的物品 = 獎勵池.Where(獎勵 => 獎勵.稀有度等級 == 物品藍圖.稀有度.稀有).ToArray();
        }
        else
        {
            稀有度裡有的物品 = 獎勵池.Where(獎勵 => 獎勵.稀有度等級 == 物品藍圖.稀有度.普通).ToArray();
        }
        foreach (var item in 稀有度裡有的物品)
        {
            Debug.Log($"物品名稱: {item.名稱}, 稀有度: {item.稀有度等級}");
        }

        return 稀有度裡有的物品;
    }
    public void 測試()
    {
        判斷稀有度();
    }
}
