Shader "Custom/DiffuseSpec" {
// 定义Shader的属性，这些属性可以在Unity编辑器中设置
Properties {
    _Color ("Color", Color) = (1,1,1,1) // 颜色属性，用于调整材质的颜色，默认为白色
    _MainTex ("Albedo (RGB)", 2D) = "white" {} // 漫反射纹理，用于存储物体的颜色信息，默认为白色
    _Glossiness ("Smoothness", Range(0,1)) = 0.5 // 光滑度属性，用于控制镜面反射的光滑程度，范围从0到1，默认为0.5
    _Metallic ("Metallic", Range(0,1)) = 0.0 // 金属度属性，用于控制物体的金属感，范围从0到1，默认为0
}

// 定义一个子着色器（SubShader），这是Shader的一部分，用于定义渲染管线的一个阶段
SubShader {
    Tags { "RenderType"="Opaque" } // 标签，指定渲染类型为不透明
    LOD 200 // 指定细节层次（Level of Detail），200是一个较高的LOD值，意味着这个SubShader会在较远的距离被渲染

    CGPROGRAM
    // 指定物理基础的Standard lighting模型，并启用所有类型的光源阴影
    #pragma surface surf Standard fullforwardshadows

    // 使用Shader模型3.0目标，以获得更好看的光照效果
    #pragma target 3.0

    sampler2D _MainTex; // 定义一个2D采样器，用于采样漫反射纹理

    struct Input {
        float2 uv_MainTex; // 输入结构体，包含纹理坐标
    };

    half _Glossiness; // 光滑度值
    half _Metallic; // 金属度值
    fixed4 _Color; // 颜色值

    // 添加实例化支持
    UNITY_INSTANCING_BUFFER_START(Props)
        // 在这里放置更多每个实例的属性
    UNITY_INSTANCING_BUFFER_END(Props)

    // 表面着色器的主体函数，用于计算表面的输出
    void surf (Input IN, inout SurfaceOutputStandard o) {
        // 从纹理和颜色计算Albedo值
        fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
        o.Albedo = c.rgb; // 设置Albedo值
        // 从属性设置金属度和光滑度
        o.Metallic = _Metallic;
        o.Smoothness = _Glossiness;
        o.Alpha = c.a; // 设置透明度
    }
    ENDCG
}

// 如果当前Shader无法使用，回退到"Diffuse"着色器
FallBack "Diffuse"
}
