using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : IDisposable
{
    const float speedAnimation = 10f;

    ObjectView playerView;
    SpriteAnimatorController coinAnimator;
    List<CoinView> coinsView;


    public CoinsController(ObjectView playerView, SpriteAnimatorController spriteAnimatorController, List<CoinView> coins)
    {
        this.playerView = playerView;
        this.coinAnimator = spriteAnimatorController;
        this.coinsView = coins;
        playerView.OnObjectContact += OnObjectContact;

        foreach (CoinView coin in coinsView)
        {
            coinAnimator.StartAnimation(coin.spriteRenderer, StateAnim.Run, true, speedAnimation);
        }
    }

    void OnObjectContact(CoinView contactView)
    {
        if (coinsView.Contains(contactView))
        {
            coinAnimator.StopAnimation(contactView.spriteRenderer);
            GameObject.Destroy(contactView.gameObject);
        }
    }

    public void Dispose()
    {
        playerView.OnObjectContact -= OnObjectContact;
    }
}
