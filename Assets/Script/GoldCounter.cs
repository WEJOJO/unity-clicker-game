using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public int Gold=10;
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
                Gold++;
                textGold.text=Gold.ToString();
            }
        }
}
