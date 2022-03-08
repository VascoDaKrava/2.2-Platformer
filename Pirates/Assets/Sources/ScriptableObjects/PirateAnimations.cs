using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{

    [CreateAssetMenu]
    [Serializable]
    public class PirateAnimations : ScriptableObject
    {
        public List<Sprite> sprites = new List<Sprite>();

    }
}
