using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScroreData
{
    public List<ScoreFix> scores;
    
    public ScroreData()
    {
        scores=new List<ScoreFix> ();
    }
}
