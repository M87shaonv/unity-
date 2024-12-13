using UnityEngine;

internal class SpecificAttributes
{
    public Matrix4x4 TransMatrix;//转换矩阵
    internal Vector3 mPos;
    internal Vector3 mScale;
    internal Quaternion mRot;
    public SpecificAttributes()
    {
        mPos = UnityEngine.Random.insideUnitSphere * 10;
        mRot = Quaternion.LookRotation(UnityEngine.Random.insideUnitSphere);
        mScale = Vector3.one * UnityEngine.Random.Range(1, 3);
        TransMatrix = Matrix4x4.TRS(mPos, mRot, mScale);//基于位置、旋转和缩放创建转换矩阵
    }
}
