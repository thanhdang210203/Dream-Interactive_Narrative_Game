using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "TextData", menuName = "TextData", order = 1)]
public class TextData : ScriptableObject
{
   [TextArea(10, 100)]
   public string []PCTexts;
   [Multiline(40)]
   public string multilineString;
}
