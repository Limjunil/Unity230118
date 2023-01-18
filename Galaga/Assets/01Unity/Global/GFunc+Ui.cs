using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static partial class GFunc
{
    public static void SetTxt(GameObject obj_, string text_)
    {
        Text Txt = obj_.GetComponent<Text>();

        if(Txt == null || Txt == default(Text)) 
        {
            return;
        }

        Txt.text = text_;
    }
}
