namespace ServiceLocatorPatterns.AudioServiceLocator
{
    //作为服务定位器，负责持有当前活动的 Audio 服务实例
    public class Locator
    {
        private static NullAudio nullService;
        private static Audio service;

        // 静态构造函数，确保在第一次访问 Locator 类之前初始化默认的服务实例
        static Locator()
        {
            nullService = new NullAudio();
            // 初始化时设置为 nullService，以防止忘记注册实际的 Audio 实现
            service = nullService;
        }

        // 返回当前注册的音频服务实例
        public static Audio GetAudio()
        {
            return service;
        }

        // 允许外部代码通过此方法注册或替换当前的音频服务实例
        public static void Provide(Audio _service)
        {
            // 如果传入 null，则使用 nullService 来代替，这通常用于禁用音频功能
            service = _service ?? nullService;
        }
    }
}