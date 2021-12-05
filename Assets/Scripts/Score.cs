using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject treeText;

    public GameObject coinText;

    public static int treesScore;

    public static int coinScore;
   

    // Update is called once per frame
    void Update()
    {
        treeText.GetComponent<Text>().text = "Trees: " + treesScore;
        coinText.GetComponent<Text>().text = "Coins: " + coinScore;
    }
}
