using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get => _instance;

    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public int coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coin = DataManager.DataCoin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoin(int amout)
    {
        coin += amout;
        DataManager.DataCoin = coin;
    }

    public int GetCoin()
    {
        return coin;
    }
}
