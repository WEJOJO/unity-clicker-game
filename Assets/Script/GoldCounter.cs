using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public Text textGold;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoldUP());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GoldUP()
        {
            while(true)
            {
                yield return new WaitForSecondsRealtime(1f);
                DataController.Instance.gameData.Gold += DataController.Instance.gameData.GoldPerSec;
                textGold.text=DataController.Instance.gameData.Gold.ToString();
                DataController.Instance.SaveGameData();
            }
        }
}
