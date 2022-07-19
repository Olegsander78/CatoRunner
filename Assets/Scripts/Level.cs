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
    [SerializeField] private int _numberLevel;
    [Space(15)]
    [SerializeField] private Quest _quest;
    public Quest Quest => _quest;

    [SerializeField] private BGMusic.MusicType _bgMusicType;
    public BGMusic.MusicType BGMusicType => _bgMusicType;

    [SerializeField] private PlayerCharacter _playerCharacter;
    public PlayerCharacter PlayerCharacter => _playerCharacter;

    [Header("Don't change! Computing:")]
    [SerializeField] private float _speedLevel;
    [SerializeField] private float _minCoordLevelSegX;
    [SerializeField] private float _maxCoordLevelSegX;
    [SerializeField] private bool _completedLevel;
    [SerializeField] private bool _lockedLevel;
    public float MinCoordLevelSegX { get => _minCoordLevelSegX; set => _minCoordLevelSegX = value; }
    public float MaxCoordLevelSegX { get => _maxCoordLevelSegX; set => _maxCoordLevelSegX = value; }
    public float StartSpeedLevel => _startSpeedLevel;
    public float SpeedLevel { get => _speedLevel; set => _speedLevel = value; }
    public int NumberLevel { get => _numberLevel; set => _numberLevel = value; }
    public bool CompletedLevel { get => _completedLevel; set => _completedLevel = value; }
    public bool LockedLevel { get => _lockedLevel; set => _lockedLevel = value; }

    [System.Serializable]
    public class ParalaxLayers
    {
        public List<VisualLevelSegment> VisualLevelSegments;

        public bool EnableParalaxLayer;
        public string NameParalaxLayer;
        public float StartSpeedParalaxLayer;
        [Header("Don't change! Computing:")]
        public float SpeedParalaxLayer;
        public float MinCoordParalaxLayerSegX;
        public float MaxCoordParalaxLayerSegX;

        public ParalaxLayers(bool enableParalaxLayer, string nameParalaxLayer, List<VisualLevelSegment> visualLevelSegments, float startSpeedParalaxLayer, 
            float speedParalaxLayer, float minCoordParalaxLayerSegX, float maxCoordParalaxLayerSegX)
        {
            EnableParalaxLayer = enableParalaxLayer;
            NameParalaxLayer = nameParalaxLayer;
            SpeedParalaxLayer = speedParalaxLayer;
            MinCoordParalaxLayerSegX = minCoordParalaxLayerSegX;
            MaxCoordParalaxLayerSegX = maxCoordParalaxLayerSegX;
        }
    }

    [Header("Level Visual Parameters:")]
    [SerializeField] private List<ParalaxLayers> _paralaxLayersMatrix;


    private void Awake()
    {
        InitLevel();
        InitParalaxLayers();
    }
    private void FixedUpdate()
    {
        MoveLevelSegment();
        MoveParalaxLayers();
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

        //PlayerCharacter.PlayerMove.OnPlayerJump += () => { GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.JumpPlayer); };
        PlayerCharacter.PlayerMove.OnPlayerJump += PlayJumpSound;
    }

    private void InitParalaxLayers()
    {
        foreach (var visualSegment in _paralaxLayersMatrix)
        {
            if (visualSegment != null && visualSegment.EnableParalaxLayer)
            {
                visualSegment.SpeedParalaxLayer = visualSegment.StartSpeedParalaxLayer;

                visualSegment.MinCoordParalaxLayerSegX = visualSegment.VisualLevelSegments[0].transform.position.x;
                visualSegment.MaxCoordParalaxLayerSegX = visualSegment.VisualLevelSegments[0].transform.position.x;

                for (int i = 1; i < visualSegment.VisualLevelSegments.Count; i++)
                {
                    if (visualSegment.MinCoordParalaxLayerSegX > visualSegment.VisualLevelSegments[i].transform.position.x)
                    {
                        visualSegment.MinCoordParalaxLayerSegX = visualSegment.VisualLevelSegments[i].transform.position.x;
                    }
                    if (visualSegment.MaxCoordParalaxLayerSegX < visualSegment.VisualLevelSegments[i].transform.position.x)
                    {
                        visualSegment.MaxCoordParalaxLayerSegX = visualSegment.VisualLevelSegments[i].transform.position.x;
                    }
                }
            }
        }
    }

    private void MoveLevelSegment()
    {
        float displacement = SpeedLevel * Time.fixedDeltaTime;

        foreach (var segment in _levelSegments)
        {
            Vector3 pos = segment.transform.position;
            pos.x -= displacement;

            if (pos.x < MinCoordLevelSegX)
            {
                pos.x = MaxCoordLevelSegX - (MinCoordLevelSegX - pos.x) + LENGHT_SEGMENT;
                segment.RollVariantLevelSegment();

                GameController.Instance.EventBus.OnLevelSegmentFinished(segment);
            }

            segment.Rigidbody.MovePosition(pos);
        }
    }

    private void MoveParalaxLayers()
    {
        foreach (var paralaxLayers in _paralaxLayersMatrix)
        {
            if (paralaxLayers != null && paralaxLayers.EnableParalaxLayer)
            {
                float displacementLayer = paralaxLayers.SpeedParalaxLayer * Time.deltaTime;

                foreach (var visualSegments in paralaxLayers.VisualLevelSegments)
                {
                    Vector3 pos = visualSegments.transform.position;
                    pos.x -= displacementLayer;
                    if (displacementLayer >= 0)
                    {

                        if (pos.x < paralaxLayers.MinCoordParalaxLayerSegX)
                        {
                            pos.x = paralaxLayers.MaxCoordParalaxLayerSegX - (paralaxLayers.MinCoordParalaxLayerSegX - pos.x) + LENGHT_VISUAL_SEGMENT;
                        }
                    }
                    else
                    {
                        if (pos.x > paralaxLayers.MaxCoordParalaxLayerSegX)
                        {
                            pos.x = paralaxLayers.MinCoordParalaxLayerSegX + (paralaxLayers.MaxCoordParalaxLayerSegX - pos.x) - LENGHT_VISUAL_SEGMENT;
                        }
                    }
                    visualSegments.RigidbodyVisualLevel.MovePosition(pos);
                }
            }
        }
    }

    public void ChangeSpeedLevel(float speedUp)
    {
        SpeedLevel *= speedUp;

        foreach (var paralaxLayer in _paralaxLayersMatrix)
        {
            paralaxLayer.SpeedParalaxLayer *= speedUp;
        }
    }
    
    public void SetStartSpeedLevels()
    {
        SpeedLevel = StartSpeedLevel;

        foreach (var paralaxLayer in _paralaxLayersMatrix)
        {
            paralaxLayer.SpeedParalaxLayer = paralaxLayer.StartSpeedParalaxLayer;
        }
    }
    
    public void CheckFinishedQuest()
    {
        if (_quest.IsQuestFinished())
        {
            _quest.CancelQuest();
            Time.timeScale = 0f;
            GameController.Instance.SoundController.StopBGMusic();
            GameController.Instance.ScreenController.PushScreen<WinScreen>();
            GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.WinLevel);
            GameController.Instance.LevelController.CompleteLevel(GameController.Instance.LevelController.CurrentLevel);

            GameController.Instance.YandexSDK.StartShowFullScreenADV();
        }
    }

    public void PlayJumpSound()
    {
        GameController.Instance.SoundController.PlaySound(SFX.SFXTypeEvents.JumpPlayer);
    }
    private void OnDestroy()
    {
        if (_playerCharacter)
            PlayerCharacter.PlayerMove.OnPlayerJump -= PlayJumpSound;
    }
}
