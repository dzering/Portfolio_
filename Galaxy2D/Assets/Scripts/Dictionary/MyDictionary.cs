using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyDictionary : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    DictionaryScriptapleObject dictionaryData;

    [SerializeField]
    List<string> keys = new List<string>();

    [SerializeField]
    List<int> values = new List<int>();

    Dictionary<string, int> myDictionary = new Dictionary<string, int>();

    public bool modifyValues;

    public void OnBeforeSerialize()
    {
        if (!modifyValues)
        {
            keys.Clear();
            values.Clear();

            for (int i = 0; i < System.Math.Min(dictionaryData.Keys.Count, dictionaryData.Values.Count); i++)
            {
                keys.Add(dictionaryData.Keys[i]);
                values.Add(dictionaryData.Values[i]);

            }
        }
    }

    public void OnAfterDeserialize()
    {

    }

    public void Deserealization()
    {
        Debug.Log("Deserealization");
        myDictionary = new Dictionary<string, int>();
        dictionaryData.Keys.Clear();
        dictionaryData.Values.Clear();
        for (int i = 0; i != System.Math.Min(keys.Count, values.Count); i++)
        {
            dictionaryData.Keys.Add(keys[i]);
            dictionaryData.Values.Add(values[i]);
            myDictionary.Add(keys[i], values[i]);
        }
        modifyValues = false;
    }

}
