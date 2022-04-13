using UnityEngine;


namespace PiratesGame
{
    public sealed class QuestPlayerChecker : IQuestCheckable
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.TryGetComponent<PirateView>(out _);
        }
    }
}
