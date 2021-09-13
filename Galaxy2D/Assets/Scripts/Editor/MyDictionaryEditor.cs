using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyDictionary))]
public class MyDictionaryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MyDictionary dictionary = target as MyDictionary;

        base.OnInspectorGUI();
        if (dictionary.modifyValues)
        {
            if(GUILayout.Button("Save changes"))
            {
                dictionary.Deserealization();
            }
        }

    }
}
