using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string npcname;

    [TextArea(3, 10)] // Amount of lines of sentences spaced below eachother, amount of words in one line
    public string[] sentences;

}