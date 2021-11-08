using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public event System.Func<bool> OnSwap;

    BookView firstbook;
    BookView secondBook;

    Vector3 startPositionFirstBook;
    float offset = 0.1f;
    bool isInGame = true;

    public PlayerController()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInGame)
        {
          //  RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                if(hit.collider.TryGetComponent<BookView>(out var enemy)){
                    Debug.Log(enemy.name);
                   
                    if (firstbook == null)
                    {
                        firstbook = enemy;
                        startPositionFirstBook = firstbook.transform.position;
                        enemy.transform.position += new Vector3(0, offset, 0);

                    }
                    else
                    {
                        secondBook = enemy;
                        Changing(firstbook, secondBook);
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(firstbook != null)
            {
                firstbook.transform.position = startPositionFirstBook;
                firstbook = null;
            }
        }
    }

    void Changing(BookView first, BookView second)
    {
        //Positions
        first.transform.position = second.transform.position;
        second.transform.position = startPositionFirstBook;

        //Shelves
        var tempID = first.ID;
        var tempShelf = first.Shelf;

        first.ID = second.ID;
        first.Shelf = second.Shelf;
        first.Shelf.Books[first.ID] = first;

        second.ID = tempID;
        second.Shelf = tempShelf;
        second.Shelf.Books[second.ID] = second;

        firstbook = null;
        secondBook = null;

        OnSwap?.Invoke();
    }

    public void SetInGame(bool inGame)
    {
        isInGame = inGame;
    }

}
