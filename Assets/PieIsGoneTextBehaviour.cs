using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PieIsGoneTextBehaviour : MonoBehaviour
{

    float timeStart = 0;
    TextMeshProUGUI text;

    public List<string> words = new List<string> { "THE ", "PIE. ", "", "", "", "", "", "", "", "", "THE ", "PIE ", "IS ", "GONE. ", "", "", "", "", "", "", "", "DEAR ", "SWEET ", "RACCOON ", " JESUS ", "", "", " THE ", " PIE ", " HAS ", " BEEN ", " TAKEN. ", "", "", "", "", "", "", "OH ", "GOD ", " NO, ", "", "", " I ", " WILL ", " NEVER ", " TASTE ", " THE ", " SWEET ", " FRUITY ", " FLESH ", " OF ", " THAT ", " BEAUTIFUL ", " SUGAR ", " FILLED ", " PASTRY. ", "", "", "", "", " (game over)" };
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart > 1)
        {
            int wordsDisplayed = (int)((Time.time - timeStart) * 5);
            string textToUse = "";
            for(int i = 0; i < wordsDisplayed && i < words.Count; i++)
            {
                textToUse += words[i];
            }
            text.text = textToUse;
        }
    }

    public void startDisplayingText()
    {
        timeStart = Time.time;
    }
}
