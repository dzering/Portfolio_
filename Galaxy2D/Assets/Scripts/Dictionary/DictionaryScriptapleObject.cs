using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dictionary Storage", menuName = "Data Objects/Dictionary Stprage Object")]
public class DictionaryScriptapleObject : ScriptableObject
{
    [SerializeField]
    List<string> keys = new List<string>();

    [SerializeField]
    List<int> values = new List<int>();

    public List<string> Keys { get => keys; set => keys = value; }
    public List<int> Values { get => values; set => values = value; }
}
