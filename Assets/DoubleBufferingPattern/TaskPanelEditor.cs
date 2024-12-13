using System;
using UnityEngine;
using UnityEditor;

public class TaskPanel : EditorWindow
{
    public string taskName = "New Task";
    public float time = 1.0f;
    public bool usingWorldTimeScale = false;
    public bool isLoop = false;
    public bool isPause = false;
    public int selectedCallbackIndex = 0; // 用于存储选中的回调函数索引

    private Schedule schedule;
    private string[] callbackFunctionNames; // 存储回调函数名称的数组

    [MenuItem("Tools/Double Buffering Pattern/Task Panel")]
    public static void ShowWindow()
    {
        GetWindow<TaskPanel>("Task Panel");
    }

    private void OnEnable()
    {
        // 初始化回调函数名称数组
        callbackFunctionNames = new[] { "Callback1", "Callback2", "Callback3", };
    }

    private void OnGUI()
    {
        GUILayout.Label("Task Panel", EditorStyles.boldLabel);

        taskName = EditorGUILayout.TextField("Task Name", taskName);
        time = EditorGUILayout.FloatField("Time", time);
        usingWorldTimeScale = EditorGUILayout.Toggle("Use World Time Scale", usingWorldTimeScale);
        isLoop = EditorGUILayout.Toggle("Is Loop", isLoop);
        isPause = EditorGUILayout.Toggle("Is Pause", isPause);

        // 下拉菜单选择回调函数
        selectedCallbackIndex = EditorGUILayout.Popup("Callback Function", selectedCallbackIndex, callbackFunctionNames);

        if (GUILayout.Button("Create Task"))
        {
            CreateTask();
        }
    }

    private void CreateTask()
    {
        Action<Task> callback = null;
        if (selectedCallbackIndex >= 0 && selectedCallbackIndex < callbackFunctionNames.Length)
        {
            string callbackFunctionName = callbackFunctionNames[selectedCallbackIndex];
            callback = (Action<Task>)Delegate.CreateDelegate(typeof(Action<Task>), this, callbackFunctionName);
        }

        // 这里假设 Schedule 是一个单例或者可以通过其他方式访问
        schedule = FindObjectOfType<Schedule>();
        if (schedule != null)
        {
            schedule.SetSchedule(taskName, time, callback, usingWorldTimeScale, isLoop, isPause);
        }
        else
        {
            Debug.LogError("Schedule object not found!");
        }
    }

    // 示例回调函数
    public void Callback1(Task task)
    {
        Debug.Log("Callback1: Task " + task.TaskName + " completed!");
    }

    public void Callback2(Task task)
    {
        Debug.Log("Callback2: Task " + task.TaskName + " completed!");
    }

    public void Callback3(Task task)
    {
        Debug.Log("Callback3: Task " + task.TaskName + " completed!");
    }
}