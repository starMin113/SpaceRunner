using UnityEngine;

public class SaveManager : AbstractSingleton<SaveManager>
{
    const string k_LevelProgress = "LevelProgress";
    const string k_Currency = "Currency";
    const string k_Xp = "Xp";
    const string k_EngineNum = "EngineNum";
    const string k_AudioSettings = "AudioSettings";
    const string k_QualityLevel = "QualityLevel";


    public void InitData()
    {
        EngineNum = 2;
    }
    public int LevelProgress
    {
        get => PlayerPrefs.GetInt(k_LevelProgress);
        set => PlayerPrefs.SetInt(k_LevelProgress, value);
    }

    public int EngineNum
    {
        get => PlayerPrefs.GetInt(k_EngineNum, 2);
        set => PlayerPrefs.SetInt(k_EngineNum, value);
    }


    /// <summary>
    /// Save and load currency as an integer
    /// </summary>
    public int Currency
    {
        get => PlayerPrefs.GetInt(k_Currency);
        set => PlayerPrefs.SetInt(k_Currency, value);
    }

    public float XP
    {
        get => PlayerPrefs.GetFloat(k_Xp);
        set => PlayerPrefs.SetFloat(k_Xp, value);
    }

    public bool IsQualityLevelSaved => PlayerPrefs.HasKey(k_QualityLevel);

    public int QualityLevel
    {
        get => PlayerPrefs.GetInt(k_QualityLevel);
        set => PlayerPrefs.SetInt(k_QualityLevel, value);
    }

    public AudioSettings LoadAudioSettings()
    {
        return PlayerPrefsUtils.Read<AudioSettings>(k_AudioSettings);
    }

    public void SaveAudioSettings(AudioSettings audioSettings)
    {
        PlayerPrefsUtils.Write(k_AudioSettings, audioSettings);
    }
}
