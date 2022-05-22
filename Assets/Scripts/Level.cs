using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public const float LENGHT_SEGMENT = 30.7f;
    public const float LENGHT_VISUAL_SEGMENT = 30.7f;

    [SerializeField] private List<LevelSegment> _levelSegments = new List<LevelSegment>();
    [SerializeField] private List<VisualLevelSegment> _visualLevelSegments = new List<VisualLevelSegment>();

    [Header("Level Parameters:")]
    [SerializeField] private float _startSpeedLevel = 3f;
    [SerializeField] private float _speedLevel;
    [SerializeField] private float _minCoordLevelSegX;
    [SerializeField] private float _maxCoordLevelSegX;
    [SerializeField] private int _numberLevel;
    [SerializeField] private bool _completedLevel;
    [SerializeField] private bool _lockedLevel;
    public float MinCoordLevelSegX { get => _minCoordLevelSegX; set => _minCoordLevelSegX = value; }
    public float MaxCoordLevelSegX { get => _maxCoordLevelSegX; set => _maxCoordLevelSegX = value; }
    public float StartSpeedLevel => _startSpeedLevel;
    public float SpeedLevel { get => _speedLevel; set => _speedLevel = value; }
    public int NumberLevel { get => _numberLevel; set => _numberLevel = value; }
    public bool CompletedLevel { get => _completedLevel; set => _completedLevel = value; }
    public bool LockedLevel { get => _lockedLevel; set => _lockedLevel = value; }

    [SerializeField] private Quest _quest;

    [SerializeField] private BGMusic.MusicType _bgMusicType;
    public BGMusic.MusicType BGMusicType => _bgMusicType;

    [SerializeField] private PlayerCharacter _playerCharacter;
    public PlayerCharacter PlayerCharacter => _playerCharacter;

    [Header("Level Visual Parameters:")]
    [SerializeField] private float _startSpeedVisualLevel = 3f;
    [SerializeField] private float _speedVisualLevel;
    [SerializeField] private float _minCoordVisualLevelSegX;
    [SerializeField] private float _maxCoordVisualLevelSegX;
    public float MaxCoordVisualLevelSegX { get => _maxCoordVisualLevelSegX; set => _maxCoordVisualLevelSegX = value; }
    public float MinCoordVisualLevelSegX { get => _minCoordVisualLevelSegX; set => _minCoordVisualLevelSegX = value; }
    public float StartSpeedVisualLevel => _startSpeedVisualLevel;
    public float SpeedVisualLevel { get => _speedVisualLevel; set => _speedVisualLevel = value; }

    

    private void Awake()
    {
        InitLevel();
        InitVisualLevel();
    }
    private void FixedUpdate()
    {
        MoveLevelSegment();
        MoveVisualLevelSegment();
        CheckFinishedQuest();
    }

    private void InitLevel()
    {
        SpeedLevel = StartSpeedLevel;

        MinCoordLevelSegX = _levelSegments[0].transform.position.x;
        MaxCoordLevelSegX = _levelSegments[0].transform.position.x;

        for (int i = 1; i < _levelSegments.Count; i++)
        {
            if (MinCoordLevelSegX > _levelSegments[i].transform.position.x) MinCoordLevelSegX = _levelSegments[i].transform.position.x;
            if (MaxCoordLevelSegX < _levelSegments[i].transform.position.x) MaxCoordLevelSegX = _levelSegments[i].transform.position.x;
        }

        GameController.Instance.LevelController.SetLevel(this);
        _quest.BeginQuest();
        GameController.Instance.SoundController.StopBGMusic();
        GameController.Instance.SoundController.PlayBGMusic(GameController.Instance.LevelController.CurrentLevel);
    }

    private void InitVisualLevel()
    {
        SpeedVisualLevel = StartSpeedVisualLevel * _visualLevelSegments[0].VelocityMultiply;

        MinCoordVisualLevelSegX = _visualLevelSegments[0].transform.position.x;
        MaxCoordVisualLevelSegX = _visualLevelSegments[0].transform.position.x;

        for (int i = 1; i < _visualLevelSegments.Count; i++)
        {
            if (MinCoordVisualLevelSegX > _visualLevelSegments[i].transform.position.x)
            { MinCoordVisualLevelSegX = _visualLevelSegments[i].transform.position.x; }

            if (MaxCoordVisualLevelSegX < _visualLevelSegments[i].transform.position.x)
            { MaxCoordVisualLevelSegX = _visualLevelSegments[i].transform.position.x; }
        }
    }    
    private void MoveLevelSegment()
    {
        float displacement = SpeedLevel * Time.fixedDeltaTime;

        foreach (var segment in _levelSegments)
        {
            Vector3 pos = segment.transform.position;
            pos.x -= displacement;

            //segment.Rigidbody.velocity = new Vector2(-SpeedLevel, 0f);

            if (pos.x < MinCoordLevelSegX)
            {
                pos.x = MaxCoordLevelSegX - (MinCoordLevelSegX - pos.x) + LENGHT_SEGMENT;
                //segment.Clear();
                //segment.Rigidbody.MovePosition(pos);
                segment.RollVariantLevelSegment();
                GameController.Instance.EventBus.OnLevelSegmentFinished(segment);
            }

            segment.Rigidbody.MovePosition(pos);
        }
    }

    private void MoveVisualLevelSegment()
    {
        float displacementVisual = SpeedVisualLevel * _visualLevelSegments[0].VelocityMultiply * Time.fixedDeltaTime;

        foreach (var visualSegments in _visualLevelSegments)
        {
            Vector3 pos = visualSegments.transform.position;
            pos.x -= displacementVisual;

            if (pos.x < MinCoordVisualLevelSegX)
            {
                pos.x = MaxCoordVisualLevelSegX - (MinCoordVisualLevelSegX - pos.x) + LENGHT_VISUAL_SEGMENT;
            }
            visualSegments.Rigidbody.MovePosition(pos);
        }
    }
    
    public void ChangeSpeedLevel(float speedUp)
    {
        SpeedLevel *= speedUp;
        SpeedVisualLevel *= speedUp * _visualLevelSegments[0].VelocityMultiply;
    } 
    
    private void CheckFinishedQuest()
    {
        if (_quest.IsQuestFinished())
        {
            Time.timeScale = 0f;
            GameController.Instance.SoundController.StopBGMusic();
            GameController.Instance.ScreenController.PushScreen<WinScreen>();
            GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.WinLevel);
            GameController.Instance.LevelController.CompleteLevel(GameController.Instance.LevelController.CurrentLevel);
        }
    }
}
