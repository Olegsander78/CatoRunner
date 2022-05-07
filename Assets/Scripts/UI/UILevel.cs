using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    [SerializeField] private GameObject _lockImage;
    public GameObject LockImage { get => _lockImage; set => _lockImage = value; }

    [SerializeField] private GameObject _unLockImage;
    public GameObject UnLockImage { get => _unLockImage; set => _unLockImage = value; }

    [SerializeField] private int _levelUINumber;
    public int LevelUINumber => _levelUINumber;

    //toDel
    [ContextMenu("LockUILevel")]
    public void LockUILevel()
    {
        _lockImage.SetActive(true);
        _unLockImage.SetActive(false);
    }

    [ContextMenu("UnLockUILevel")]
    public void UnLockUILevel()
    {
        _lockImage.SetActive(false);
        _unLockImage.SetActive(true);
    }
    
}
