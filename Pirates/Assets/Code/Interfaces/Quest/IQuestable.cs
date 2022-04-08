using System;


namespace PiratesGame
{
    public interface IQuestable
    {
        event Action<IQuestable> Completed;

        bool IsCompete { get; }
    }
}
