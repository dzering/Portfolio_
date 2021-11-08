using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator : IColoring
{
    int colorAmount;
    Color res;
    Color[] colors;
    Dictionary<Color, int> dictionary = new Dictionary<Color, int>();

    public ColorGenerator(int shelvesAmount)
    {
        colorAmount = shelvesAmount;
        colors = new Color[colorAmount];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Random.ColorHSV();
            dictionary.Add(colors[i], 0);
        }
    }

    public Color Coloring(int shelvesCapacity)
    {

        var rnd = Random.Range(0, colors.Length);

        if (dictionary[colors[rnd]] < shelvesCapacity)
        {
            dictionary[colors[rnd]] += 1;
            return colors[rnd];
        }

        else
        {
            dictionary.Remove(colors[rnd]);
            colors = colors.Where((s, index) => index != rnd).ToArray();
            for (int i = 0; i < colors.Length; i++)
            {
                if(dictionary[colors[i]] != shelvesCapacity)
                {
                    res = colors[i];
                    dictionary[colors[i]] += 1;
                    break;
                }
            }
            return res;
           
        }
    }
    
}
