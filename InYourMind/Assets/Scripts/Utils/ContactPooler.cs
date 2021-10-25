using UnityEngine;

public class ContactPooler
{
    Collider2D collider;
    ContactPoint2D[] contacts = new ContactPoint2D[10];

    const float collTreshold = 0.6f;
    int contactCount;

    public bool IsGrouded { get; private set; }
    public bool HasLeftContact { get; private set; }
    public bool HasRigthContact { get; private set; }

    public ContactPooler(Collider2D collider)
    {
        this.collider = collider;
    }

    public void Update()
    {
        IsGrouded = false;
        HasLeftContact = false;
        HasRigthContact = false;

        contactCount = collider.GetContacts(contacts);


        for (int i = 0; i < contactCount; i++)
        {
            if (contacts[i].normal.y > collTreshold) IsGrouded = true;
            if (contacts[i].normal.x > collTreshold) HasLeftContact = true;
            if (contacts[i].normal.x < collTreshold) HasRigthContact = true;

        }
    }
}
