using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace ServiceLocatorPatterns.AnotherImplementation
{
    // 服务定位器类，使用静态上下文来存储已经注册的对象，并允许从任何地方解析（获取）这些对象。
    public static class ServiceLocator
    {
        // 使用 ConcurrentDictionary 来存储已注册的服务实例，确保线程安全和高效查找。
        private static readonly ConcurrentDictionary<Type, object> _registeredServices;

        // 静态构造函数，在第一次使用该类的静态成员或创建该类的第一个实例之前自动执行,不需要显式地调用静态构造函数
        static ServiceLocator()
        {
            _registeredServices = new ConcurrentDictionary<Type, object>();
        }

        // Register 方法用来向服务定位器中注册一个服务实例。
        // T 是泛型类型参数，限定只能是 class 类型。
        public static bool Register<T>(T service) where T : class
        {
            try
            {
                if (_registeredServices.ContainsKey(typeof(T)))
                    throw new Exception($"ServiceLocator: {typeof(T)} has already been registered."); // 已经注册过该类型，抛出异常
                _registeredServices[typeof(T)] = service;
                Debug.Log($"ServiceLocator: Registered {typeof(T)}");
                return true;
            } catch (Exception e)
            {
                Debug.LogError($"ServiceLocator: Failed to register {typeof(T)}: {e.Message}");
                return false;
            }
        }

        // Unregister 方法从服务定位器中注销一个具体的服务实例。
        // 如果该实例不再需要或对象被销毁时调用。
        public static bool Unregister<T>(T instance) where T : class
        {
            if (!_registeredServices.TryGetValue(typeof(T), out object obj)) return false;
            if (!ReferenceEquals(obj, instance)) return false; //比较两个引用类型的对象是否指向同一个内存地址。对于引用类型来说，这意味着它们实际上是指向同一个对象实例
            if (!_registeredServices.TryRemove(typeof(T), out _)) return false;

            Debug.Log($"ServiceLocator: Unregistered {typeof(T)}");
            return true;
        }

        // Resolve 方法尝试解析指定类型的服务实例。
        // 如果找到则返回该实例，否则返回 null。
        public static T Resolve<T>() where T : class
        {
            if (_registeredServices.TryGetValue(typeof(T), out object obj))
            {
                return (T)obj;
            }

            return null;
        }
    }
}