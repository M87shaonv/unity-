using System;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    // 双缓冲列表，用于防止在计时器回调期间直接修改计时器队列
    [SerializeField] private List<Task> _Front; // _Front 用于收集新添加的任务
    [SerializeField] private List<Task> _Back; // _Back 用于迭代和处理任务

    // 收集需要被移除的 Schedule 对象，避免在迭代过程中直接修改 _Back 列表
    [SerializeField] private List<Task> _Garbage;

    private static Schedule Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(this);
        _Front = new List<Task>();
        _Back = new List<Task>();
        _Garbage = new List<Task>();
    }

    // 设置一个新的调度任务
    public Task SetSchedule(string bindName, float time, Action<Task> callback, bool usingWorldTimeScale = false
        , bool isLoop = false, bool isPause = false)
    {
        // 创建一个新的 Schedule 实例，并将其添加到 _Front 队列中
        var sd = new Task(bindName, time, callback, usingWorldTimeScale, isLoop, isPause);
        _Front.Add(sd);
        Debug.Log("Schedule: " + _Front.Count + " tasks added.");
        return sd;
    }

    public void SetSchedule(Task sd)
    {
        if (_Back.Contains(sd))
        {
            // 如果已经在 _Back 中，则不需要再次添加
            return;
        }

        if (!_Front.Contains(sd))
        {
            // 如果不在 _Front 中，则添加回去
            _Front.Add(sd);
        }
    }

    public void RemoveSchedule(Task sd)
    {
        if (sd == null) return;
        _Front.Remove(sd);
        _Back.Remove(sd);
    }


    // 更新所有调度任务的状态
    private void Update()
    {
        // 将 _Front 中的所有新任务转移到 _Back，然后清空 _Front
        if (_Front.Count > 0)
        {
            _Back.AddRange(_Front);
            _Front.Clear();
        }

        float dt = Time.deltaTime; // 获取自上次调用以来的时间差

        foreach (Task s in _Back)
        {
            // 检查任务是否已被取消，若取消则标记为垃圾并跳过
            if (s.Canceled)
            {
                _Garbage.Add(s);
                continue;
            }

            if (s.IsPause)
            {
                continue;
            }

            Task sd = s;

            // 计算剩余时间，是否使用世界时间比例
            float tmpTime = sd.Time;
            var InGameTimeScale = 1.0f; // 假设游戏未暂停，时间比例为 1.0f,可以被加快或减慢
            tmpTime -= sd.UsingWorldTimeScale ? dt * InGameTimeScale : dt;

            // 更新 Schedule 的剩余时间
            sd.ResetTime(tmpTime);


            if (tmpTime > 0) continue;
            // 如果时间已经到了或超过了触发点，则执行回调函数
            s.Callback?.Invoke(s);
            if (s.IsLoop)
            {
                s.ResetTime(s.OriginalTime); // 重置时间为原始时间
            }
            else
            {
                _Garbage.Add(s); // 标记为垃圾
            }
        }

        // 清理已完成或被取消的任务
        Debug.Log("Schedule: " + _Garbage.Count + " garbage tasks removed.");
        foreach (Task s in _Garbage)
        {
            if (_Back.Contains(s))
            {
                _Back.Remove(s); // 从 _Back 移除垃圾任务
            }
        }

        _Garbage.Clear(); // 清空垃圾列表
    }
}