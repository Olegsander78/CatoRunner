using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using profile;

public class PlayerProfile : MonoBehaviour
{
    private static ProtoSerializer ps = new ProtoSerializer();
    private profile.PlayerProfile _playerProfile;
    public profile.PlayerProfile Profile => _playerProfile; 

    private void Start()
    {
        Load();
    }
    private void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        ps.Serialize(stream, _playerProfile);
        SaveData("profile.save", stream);
    }

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
