using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest", menuName = "Level/BasicQuest")]
public class BasicQuest : Quest
{
    public int TargetDistance;
    public int TargetEnemies;
    public int TargetCoins;

    private int _currentDistance;
    private int _currentEnemies;
    private int _currentCoins;

    public override void BeginQuest()
    {
        _currentCoins = 0;
        _currentEnemies = 0;
        _currentDistance = 0;

        GameController.Instance.EventBus.onEnemyDefeated += OnEnemyDefeated;
        GameController.Instance.EventBus.onLevelSegmentFinishted += OnLevelSegmentFinished;
        GameController.Instance.EventBus.onCoinCollected += OnCoinCollected;
    }

    public override bool IsQuestFinisheted()
    {
        return _currentDistance >= TargetDistance && _currentEnemies >= TargetEnemies && _currentCoins >= TargetCoins;
    }

    private void OnEnemyDefeated(Enemy enemy)
    {
        _currentEnemies++;
    }

    private void OnLevelSegmentFinished(LevelSegment levelSegment)
    {
        _currentDistance++;
    }

    private void OnCoinCollected(int coinAmaunt)
    {
        _currentCoins += coinAmaunt;
    }

    public override void CancelQuest()
    {
        GameController.Instance.EventBus.onEnemyDefeated -= OnEnemyDefeated;
        GameController.Instance.EventBus.onLevelSegmentFinishted -= OnLevelSegmentFinished;
        GameController.Instance.EventBus.onCoinCollected -= OnCoinCollected;
    }
}

