using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController
{
    public event System.Func<bool> OnVictory;
    ShelfView[] shelves;
    UIView endGameMenuView;

    bool isVictory = false;

    public VictoryController(ShelfView[] shelves, UIView endGameMenuView)
    {
        this.shelves = shelves;
        this.endGameMenuView = endGameMenuView;
    }

    public bool IsVictory { get => isVictory; set => isVictory = value; }

    public bool Check()
    { 
        foreach (var shelf in shelves)
        {
            for (int i = 1; i < shelf.Books.Length; i++)
            {
                if(shelf.Books[i - 1].Color != shelf.Books[i].Color)
                {
                    return IsVictory == false;
                }
            }
        }

        endGameMenuView.gameObject.SetActive(true);
        OnVictory?.Invoke();
        return IsVictory == true;
    }
}
