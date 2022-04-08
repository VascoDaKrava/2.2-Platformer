using UnityEngine;


namespace PiratesGame
{
    public interface IQuestCheckable
    {
        bool TryComplete(GameObject activator);
    }
}
