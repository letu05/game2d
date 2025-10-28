using UnityEngine;

public static class DataManager 

{
    public static int DataCoin
    {
        get => PlayerPrefs.GetInt(DataKey.DatatCoin, 0);
        set => PlayerPrefs.SetInt(DataKey.DatatCoin, value);
    }
    
}
