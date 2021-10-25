using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateAnim
{
    Idle = 0,
    Run = 1,
    Jump = 2
}

[CreateAssetMenu(fileName ="SpriteAnimatorCfg", menuName ="Configs/Animation", order = 1)]
public class SpriteRenderConfig : ScriptableObject
{
    public List<SpritesSequence> Sequence = new List<SpritesSequence>();
}

[System.Serializable]
public sealed class SpritesSequence
{
    public StateAnim trackAninm;
    public List<Sprite> sprites = new List<Sprite>();
}
