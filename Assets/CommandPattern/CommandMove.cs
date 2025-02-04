﻿using UnityEngine;

public class CommandMove : Command {

    private Vector3 TransPos;

    public CommandMove(Vector3 transPos, float time)
    {
        TransPos = transPos;
        _TheTime = time;//命令执行时间
    }
    public override void execute(Avatar avatar)
    {
        avatar.Move(TransPos);
    }
    public override void undo(Avatar avatar)
    {
        avatar.Move(-TransPos);
    }
}
