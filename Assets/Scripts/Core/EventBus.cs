using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    public event Action<int> onCoinCollected;
    public event Action<Enemy> onEnemyDefeated;
    public event Action<LevelSegment> onLevelSegmentFinishted;

    public void OnCoinCollected(int coinsAmount)
    {
        onCoinCollected?.Invoke(coinsAmount);
    }

    public void OnEnemydefeated(Enemy enemy)
    {
        onEnemyDefeated?.Invoke(enemy);
    }

    public void OnLevelSegmentFinished(LevelSegment levelSegment)
    {
        onLevelSegmentFinishted?.Invoke(levelSegment);
    }

}
