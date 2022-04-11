using System;


namespace PiratesGame
{
    public interface IQuestable
    {
        event Action<IQuestable, QuestObjectView> Completed;

        bool IsCompete { get; }
    }
}
