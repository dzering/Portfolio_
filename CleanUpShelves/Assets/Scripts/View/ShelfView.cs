using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfView : MonoBehaviour
{
    BookView[] books;

    public BookView[] Books { get => books; set => books = value; }
}
