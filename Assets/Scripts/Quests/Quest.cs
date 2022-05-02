using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Quest : ScriptableObject
{

    public abstract void BeginQuest();

    public abstract bool IsQuestFinished();

    public abstract void CancelQuest();
}
