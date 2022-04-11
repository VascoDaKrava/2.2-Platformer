using UnityEngine;


namespace PiratesGame
{
    [CreateAssetMenu]
    public sealed class QuestConfigSO : ScriptableObject
    {

        public QuestType TypeOfQuest;

        public QuestTargetView QuestTargetViewObject;
        
    }
}
