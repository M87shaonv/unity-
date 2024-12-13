using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandManager : MonoBehaviour
{

    public Avatar TheAvatar;
    private Text StatusText;
    private Stack<Command> mCommandStack;
    private float mCallBackTime;
    public bool IsRun = true;

    void Start()
    {
        mCommandStack = new Stack<Command>();
        mCallBackTime = 0;
        StatusText=GameObject.Find("StatusText").GetComponent<Text>();
        StatusText.text= "当前状态：" + (IsRun ? "控制" : "回溯");
    }

    void Update()
    {
        if (IsRun)
        {
            Control();
        }
        else
        {
            RunCallBack();
        }

    }

    public void SetRun()
    {
        IsRun= !IsRun;
        StatusText.text= "当前状态：" + (IsRun ? "控制" : "回溯");
    }
    private void RunCallBack()
    {
        /*在每一帧更新时递减m_CallBackTime。一旦m_CallBackTime小于某个命令的TheTime,就表示已经过了足够的时间,可以安全地撤销这个命令
         因此undo方法会被调用，以撤销之前执行的动作*/
        mCallBackTime -= Time.deltaTime;
        if (mCommandStack.Count > 0 && mCallBackTime < mCommandStack.Peek().TheTime)
        {
            mCommandStack.Pop().undo(TheAvatar);
        }
    }

    private Command InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return new CommandMove(new Vector3(0, Time.deltaTime, 0), mCallBackTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            return new CommandMove(new Vector3(0, -Time.deltaTime, 0), mCallBackTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            return new CommandMove(new Vector3(-Time.deltaTime, 0, 0), mCallBackTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            return new CommandMove(new Vector3(Time.deltaTime, 0, 0), mCallBackTime);
        }
        return null;
    }

    private void Control()
    {
        mCallBackTime += Time.deltaTime;
        Command cmd = InputHandler();
        if (cmd != null)
        {
            mCommandStack.Push(cmd);
            cmd.execute(TheAvatar);
        }
    }
}
