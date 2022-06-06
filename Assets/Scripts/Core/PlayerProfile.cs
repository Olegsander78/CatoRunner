using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using profile;

public class PlayerProfile : MonoBehaviour
{
    private static ProtoSerializer ps = new ProtoSerializer();
    [SerializeField] private profile.PlayerProfile _playerProfile;
    public profile.PlayerProfile Profile => _playerProfile; 

    private void Start()
    {
        DontDestroyOnLoad(this);
        Debug.Log("BeforeStartLoad - " + GameController.Instance.PlayerProfile.Profile.LastUnlockLevel);
        Load();
        Debug.Log("AfterStartLoad - " + GameController.Instance.PlayerProfile.Profile.LastUnlockLevel);
    }
    private void OnDestroy()
    {
        //Save();
    }
    public void Save()
    {
        Debug.Log("BeforeStartSave - " + Profile.LastUnlockLevel);
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        ps.Serialize(stream, Profile);
        SaveData("profile.save", stream);
        Debug.Log("AfterStartSave - " + Profile.LastUnlockLevel);
    }

    [ContextMenu("SaveData")]
    private void SaveData(string fileName, System.IO.MemoryStream stream)
    {
        System.IO.File.Delete(fileName);
        var fileStream = System.IO.File.OpenWrite(fileName);
        try
        {
            stream.WriteTo(fileStream);
            stream.Close();
            fileStream.Close();
            Debug.Log("Saved successfull");
            if (_playerProfile == null)
            {
                Debug.Log("Saved Game is null");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Saving Exception: " + e.Message);
            stream.Close();
            fileStream.Close();
        }
    }

    [ContextMenu("LoadProfile")]
    private profile.PlayerProfile Load()
    {
        profile.PlayerProfile profile = null;
        var saveGameFileName = "profile.save";
        var fs = LoadFileStream(saveGameFileName);
        try
        {
            profile = (profile.PlayerProfile)ps.Deserialize(fs, profile, typeof(profile.PlayerProfile));
            fs.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Corrupted or lost " + saveGameFileName + " file:   " + e.Message);
            fs.Close();
            System.IO.File.Delete(saveGameFileName);
            profile = new profile.PlayerProfile();
            Debug.Log("Ошибка загрузки!");
        }
        return profile;
    }
    private System.IO.FileStream LoadFileStream(string fileName)
    {
        if (System.IO.File.Exists(fileName))
        {
            return System.IO.File.OpenRead(fileName);
        }
        else
        {
            return System.IO.File.Create(fileName);
        }
    }
}
