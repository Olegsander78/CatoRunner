using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public const float LENGHT_SEGMENT = 30.7f;
    public const float LENGHT_VISUAL_SEGMENT = 30.7f;

    [SerializeField] private List<LevelSegment> _levelSegments = new List<LevelSegment>();

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
    
    [Space(15)]
    [SerializeField] private Quest _quest;

    [SerializeField] private BGMusic.MusicType _bgMusicType;
    public BGMusic.MusicType BGMusicType => _bgMusicType;

    [SerializeField] private PlayerCharacter _playerCharacter;
    public PlayerCharacter PlayerCharacter => _playerCharacter;

    //[Header("Level Visual Parameters:")]
    //[SerializeField] private List<VisualLevelSegment> _visualTopLevelSegments = new List<VisualLevelSegment>();
    //[SerializeField] private List<VisualLevelSegment> _visualMiddleLevelSegments = new List<VisualLevelSegment>();
    //[SerializeField] private List<VisualLevelSegment> _visualBackLevelSegments = new List<VisualLevelSegment>();
    //[Space(15)]
    //[SerializeField] private float _startSpeedVisualLevel = 3f;
    //[SerializeField] private float _speedVisualLevel;

    //[SerializeField] private float _minCoordVisualTopLevelSegX;
    //[SerializeField] private float _maxCoordVisualTopLevelSegX;
    //[SerializeField] private float _minCoordVisualMiddleLevelSegX;
    //[SerializeField] private float _maxCoordVisualMiddleLevelSegX;
    //[SerializeField] private float _minCoordVisualBackLevelSegX;
    //[SerializeField] private float _maxCoordVisualBackLevelSegX;

    //public float MaxCoordVisualLevelSegX { get => _maxCoordVisualLevelSegX; set => _maxCoordVisualLevelSegX = value; }
    //public float MinCoordVisualLevelSegX { get => _minCoordVisualLevelSegX; set => _minCoordVisualLevelSegX = value; }
    //public float StartSpeedVisualLevel => _startSpeedVisualLevel;
    //public float SpeedVisualLevel { get => _speedVisualLevel; set => _speedVisualLevel = value; }
    [System.Serializable]
    public class VisualLevelsNote
    {
        public List<VisualLevelSegment> VisualLevelSegments;

        public bool EnableVisualLevel;
        public string NameVisualLevel;
        public float StartSpeedVisualLevel;
        public float SpeedVisualLevel;
        public float MinCoordVisualLevelSegX;
        public float MaxCoordVisualLevelSegX;
        public float VelocityMultiplyVisualLevel;

        public VisualLevelsNote(bool enableVisualLevel, string nameLevel, List<VisualLevelSegment> visualLevelSegments, float startSpeedVisualLevel, 
            float speedVisualLevel, float minCoordVisualLevelSegX, float maxCoordVisualLevelSegX, float velocityMultiplyVisualLevel)
        {
            EnableVisualLevel = enableVisualLevel;
            NameVisualLevel = nameLevel;
            SpeedVisualLevel = speedVisualLevel;
            MinCoordVisualLevelSegX = minCoordVisualLevelSegX;
            MaxCoordVisualLevelSegX = maxCoordVisualLevelSegX;
            VelocityMultiplyVisualLevel = velocityMultiplyVisualLevel;
        }
    }

    [Header("Level Visual Parameters:")]
    [SerializeField] private List<VisualLevelsNote> _visualLevelsNotes;


    private void Awake()
    {
        InitLevel();
        //InitVisualLevels();
    }
    private void FixedUpdate()
    {
        MoveLevelSegment();
        //MoveVisualLevelSegment();
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

    //private void InitVisualLevel(List<VisualLevelSegment> visualLevelSegments, out float minCoordVisualLevelSegX, out float maxCoordVisualLevelSegX)
    //{
    //    SpeedVisualLevel = StartSpeedVisualLevel * visualLevelSegments[0].VelocityMultiply;

    //    float minCoordVisualLevelSegX = visualLevelSegments[0].transform.position.x;
    //    float maxCoordVisualLevelSegX = visualLevelSegments[0].transform.position.x;

    //    for (int i = 1; i < visualLevelSegments.Count; i++)
    //    {
    //        if (minCoordVisualLevelSegX > visualLevelSegments[i].transform.position.x)
    //        { minCoordVisualLevelSegX = visualLevelSegments[i].transform.position.x; }

    //        if (maxCoordVisualLevelSegX < visualLevelSegments[i].transform.position.x)
    //        { maxCoordVisualLevelSegX = visualLevelSegments[i].transform.position.x; }
    //    }
    //}
    private void InitVisualLevels()
    {
        foreach (var visualSegment in _visualLevelsNotes)
        {
            visualSegment.SpeedVisualLevel = visualSegment.StartSpeedVisualLevel * visualSegment.VelocityMultiplyVisualLevel;

            visualSegment.MinCoordVisualLevelSegX = visualSegment.VisualLevelSegments[0].Transform.position.x;
            visualSegment.MaxCoordVisualLevelSegX = visualSegment.VisualLevelSegments[0].Transform.position.x;


        }

        //for (int i = 1; i < visualLevelSegments.Count; i++)
        //{
        //    if (minCoordVisualLevelSegX > visualLevelSegments[i].transform.position.x)
        //    { minCoordVisualLevelSegX = visualLevelSegments[i].transform.position.x; }

        //    if (maxCoordVisualLevelSegX < visualLevelSegments[i].transform.position.x)
        //    { maxCoordVisualLevelSegX = visualLevelSegments[i].transform.position.x; }
        //}
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

    //private void MoveVisualLevelSegment()
    //{
    //    float displacementVisual = SpeedVisualLevel * _visualLevelSegments[0].VelocityMultiply * Time.fixedDeltaTime;

    //    foreach (var visualSegments in _visualLevelSegments)
    //    {
    //        Vector3 pos = visualSegments.transform.position;
    //        pos.x -= displacementVisual;

    //        if (pos.x < MinCoordVisualLevelSegX)
    //        {
    //            pos.x = MaxCoordVisualLevelSegX - (MinCoordVisualLevelSegX - pos.x) + LENGHT_VISUAL_SEGMENT;
    //        }
    //        visualSegments.Rigidbody.MovePosition(pos);
    //    }
    //}
    
    public void ChangeSpeedLevel(float speedUp)
    {
        SpeedLevel *= speedUp;
        //SpeedVisualLevel *= speedUp * _visualLevelSegments[0].VelocityMultiply;
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
