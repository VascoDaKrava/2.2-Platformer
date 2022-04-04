using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{

    [CreateAssetMenu]
    [Serializable]
    public class AnimationsSO : ScriptableObject
    {
        public List<Sprite> SpriteList = new List<Sprite>();
    }
}
