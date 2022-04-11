using UnityEngine;


namespace PiratesGame
{
    public sealed class QuestPlayerChecker : IQuestCheckable
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TagsAndLayers.TAG_PLAYER);
        }
    }
}
