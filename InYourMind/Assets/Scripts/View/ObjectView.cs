using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectView : MonoBehaviour
{
    [SerializeField] Transform transformObj;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Collider2D colliderObject;
    [SerializeField] public Rigidbody2D rigidbodyObject;

    public System.Action<CoinView> OnObjectContact { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinView coin = collision.gameObject.GetComponent<CoinView>();
        OnObjectContact?.Invoke(coin);
    }
}
