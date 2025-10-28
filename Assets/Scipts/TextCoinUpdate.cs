using System.Collections;
using TMPro;
using UnityEngine;

public class TextCoinUpdate : MonoBehaviour
{
    public TextMeshProUGUI coinText;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(UpdateCoin());
    }

    // Update is called once per frame
    IEnumerator UpdateCoin()
    {
        while (true)
        {
        yield return new WaitForSeconds(0.5f);
        coinText.text =   GameManager.Instance.GetCoin().ToString();         
        }
        
    }
}
