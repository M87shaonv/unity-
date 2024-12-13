using UnityEngine;

public class CubeBase : MonoBehaviour
{
    private MeshRenderer mMR;
    private MeshFilter mMF;
    public Mesh mSharedMesh;
    public Material mSharedMaterial;
    private Matrix4x4[] TransInfos;

    private void Start()
    {
        Init();
    }
    //初始化组件和共享材质和网格
    public void Init()
    {
        mMR = GetComponent<MeshRenderer>();
        mMF = GetComponent<MeshFilter>();

        if (mMR == null)
        {
            Debug.LogError("MeshRenderer component is missing on the GameObject.");
            return;
        }
        if (mMF == null)
        {
            Debug.LogError("MeshFilter component is missing on the GameObject.");
            return;
        }

        mSharedMaterial = mMR.sharedMaterial;
        mSharedMesh = mMF.sharedMesh;

        if (mSharedMesh == null)
        {
            Debug.LogError("The shared mesh in the MeshFilter is null. Ensure a valid mesh is assigned.");
        }
    }
    //使用Graphics.DrawMeshInstanced方法绘制实例化网格
    internal void ObjInstancing(int num)
    {
        if (mSharedMesh == null)
        {
            Debug.LogError("Cannot draw instances because the shared mesh is null.");
            return;
        }

        TransInfos = new Matrix4x4[num];
        for (int i = 0; i < num; i++)
        {
            SpecificAttributes sa = new SpecificAttributes();
            TransInfos[i] = sa.TransMatrix;
        }

        Graphics.DrawMeshInstanced(mSharedMesh, 0, mSharedMaterial, TransInfos);
    }
}