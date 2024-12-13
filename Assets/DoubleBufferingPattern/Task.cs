using System;

[Serializable]
public class Task
{
    public bool Canceled; // 是否取消任务
    public float OriginalTime; // 存储原始时间
    public float Time; // 任务持续时间
    public bool UsingWorldTimeScale; // 是否使用世界时间比例
    public bool IsLoop; // 是否循环
    public bool IsPause; // 是否暂停
    public string TaskName; // 任务名称
    public Action<Task> Callback; // 任务完成时的回调函数

    public Task(string taskTaskName, float time, Action<Task> callback, bool usingWorldTimeScale = false
        , bool isLoop = false, bool isPause = false)
    {
        Time = time;
        OriginalTime = time;
        UsingWorldTimeScale = usingWorldTimeScale;
        TaskName = taskTaskName;
        IsLoop = isLoop;
        IsPause = isPause;
        Callback = callback;
    }

    public Task(float t, Action<Task> callback)
    {
        Time = t;
        Callback = callback;
    }

    public void Cancel()
    {
        Canceled = true;
    }

    public void ResetTime(float t)
    {
        Time = t;
    }
}