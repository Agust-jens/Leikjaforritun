using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject Door;
    private bool doorDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();

        if(coinCount == 6 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(Door);
        }
    }
}
