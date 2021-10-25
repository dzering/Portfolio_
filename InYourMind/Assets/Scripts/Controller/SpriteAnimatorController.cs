using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimatorController : IDisposable
{
    Dictionary<SpriteRenderer, Animation> activeAnimations = new Dictionary<SpriteRenderer, Animation>();
    SpriteRenderConfig configs;

    public SpriteAnimatorController(SpriteRenderConfig config)
    {
        this.configs = config;
    }

    sealed class Animation
    {
        public StateAnim trackName;
        public List<Sprite> sprites;
        public bool loop;
        public float speedPlaybackAnim;
        public float counter;
        public bool sleep;

        public void Update()
        {
            if (sleep) return;
            counter += Time.deltaTime * speedPlaybackAnim;
            if (loop)
            {
                while(counter > sprites.Count)
                {
                    counter -= sprites.Count;
                }
            }else if(counter > sprites.Count){
                counter = sprites.Count;
                sleep = true;

            }

        }

    }

    public void StartAnimation(SpriteRenderer spriteRenderer, StateAnim track, bool loop, float speed)
    {
        if(activeAnimations.TryGetValue(spriteRenderer, out var animation))
        {
            animation.sleep = false;
            animation.loop = loop;
            animation.speedPlaybackAnim = speed;
            if(animation.trackName != track)
            {
                animation.trackName = track;
                animation.sprites = configs.Sequence.Find(s => s.trackAninm == track).sprites;
                animation.counter = 0;
            }
        }
        else
        {
            activeAnimations.Add(spriteRenderer, new Animation() {
            loop = loop,
            speedPlaybackAnim = speed,
            trackName = track,
            sprites = configs.Sequence.Find(s => s.trackAninm == track).sprites
            }
            
            );
        }
    }

    public void StopAnimation(SpriteRenderer spriteRenderer)
    {
        if (activeAnimations.ContainsKey(spriteRenderer))
        {
            activeAnimations.Remove(spriteRenderer);
        }
    }

    public void Update()
    { 
        foreach (var animation in activeAnimations)
        {
            animation.Value.Update();
            if (animation.Value.counter < animation.Value.sprites.Count)
            {
                animation.Key.sprite = animation.Value.sprites[(int)animation.Value.counter];
            }
        }
    }
    public void Dispose()
    {
        activeAnimations.Clear();
    }
}
