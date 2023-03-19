using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public bool IsFinished { get; protected set; }
    [HideInInspector] public NPC Npc;

    public virtual void Init() { }
    public abstract void Run();
    public virtual void Stop() { }

    public virtual void SetPlayer(Player player) { }
}
