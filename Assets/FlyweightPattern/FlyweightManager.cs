using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyweightManager : MonoBehaviour
{

    public GameObject TheObj;
    public bool IsFlyweight=true;
    private Text StatusText;
    private List<Transform> ObjTrs;

    void Start()
    {
        ObjTrs = new List<Transform>();
        StatusText=GameObject.Find("StatusText").GetComponent<Text>();
        StatusText.text= IsFlyweight?"禁用享元模式":"启用享元模式";
    }

    void Update()
    {
        if (IsFlyweight)
        {
            GenerateObjsWithInstancing(1000);
        }
        else
        {
            GenerateObjsWithoutInstancing(1000);
        }
    }

    public void SwitchFlyweight()
    {
        IsFlyweight = !IsFlyweight;
        StatusText.text= IsFlyweight?"禁用享元模式":"启用享元模式";
    }

    //使用CubeBase脚本的ObjInstancing方法来生成指定数量的实例化对象
    public void GenerateObjsWithInstancing(int num)
    {
        // 遍历 ObjTrs 列表，销毁所有已经存在的游戏对象
        for (int i = 0; i < ObjTrs.Count; i++)
        {
            Destroy(ObjTrs[i].gameObject);
        }
        // 清空 ObjTrs 列表，移除所有引用
        ObjTrs.Clear();

        // 调用 CubeBase 脚本的 ObjInstancing 方法来生成指定数量的实例化对象
        TheObj.GetComponent<CubeBase>().ObjInstancing(num);
    }
    //创建非实例化对象
    public void GenerateObjsWithoutInstancing(int num)
    {
        // 遍历 ObjTrs 列表，销毁所有已经存在的游戏对象
        for (int i = 0; i < ObjTrs.Count; i++)
        {
            Destroy(ObjTrs[i].gameObject);
        }
        // 清空 ObjTrs 列表，移除所有引用
        ObjTrs.Clear();

        // 循环创建指定数量的新游戏对象
        for (int i = 0; i < num; i++)
        {
            // 创建 SpecificAttributes 实例，用于存储新对象的属性
            SpecificAttributes sa = new SpecificAttributes();

            // 使用 Instantiate 方法创建 TheObj 的副本，并设置其位置和旋转
            Transform tr = Instantiate(TheObj, sa.mPos, sa.mRot).transform;

            // 设置新对象的材质颜色为白色
            tr.GetComponent<MeshRenderer>().material.color = Color.white;

            // 设置新对象的局部缩放
            tr.localScale = sa.mScale;

            // 将新创建的对象的 Transform 添加到 ObjTrs 列表中
            ObjTrs.Add(tr);
        }
    }
}
