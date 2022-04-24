using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Quest : ScriptableObject
{

    public abstract void BeginQuest();

    public abstract bool IsQuestFinisheted();

    public abstract void CancelQuest();
}
