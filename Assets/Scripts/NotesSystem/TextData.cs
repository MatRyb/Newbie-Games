using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Note", menuName = "Notes System/new Note")]
public class TextData : ScriptableObject
{
    [TextArea(5,20)]
    [SerializeField] string text;
    public string Text { get { return text; } }
}
