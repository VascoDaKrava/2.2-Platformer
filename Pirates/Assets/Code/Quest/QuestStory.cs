using UnityEngine;


namespace PiratesGame
{
    public sealed class QuestStory : MonoBehaviour
    {

        #region Fields

        [Space]
        [SerializeField]
        private QuestType _questType;

        [Space]
        [SerializeField]
        private QuestObjectView[] _questObjects;

        [SerializeField]
        private QuestTargetView _questTarget;

        private QuestObjectController[] _questControllers;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _questControllers = new QuestObjectController[_questObjects.Length];

            for (int i = 0; i < _questObjects.Length; i++)
            {
                _questControllers[i] = new QuestObjectController(new QuestPlayerChecker(), _questObjects[i]);
                _questControllers[i].Completed += OnQuestComplete;
            }
        }

        public void OnDestroy()
        {
            foreach (var quest in _questControllers)
            {
                quest.Completed -= OnQuestComplete;
                quest.Dispose();
            }
        }

        #endregion


        #region Methods

        private void OnQuestComplete(IQuestable quest, QuestObjectView caller)
        {
            switch (_questType)
            {
                case QuestType.Collector:
                    QuestSwitchComplete(quest);
                    break;

                case QuestType.Chain:
                    QuestChainComplete(quest, caller);
                    break;

                default:
                    break;
            }

            if (CheckStoryComplete())
            {
                _questTarget.QuestDone();
            }
        }

        private void QuestSwitchComplete(IQuestable quest)
        {
            _questTarget.QuestStepFinish();
            quest.Completed -= OnQuestComplete;
        }

        private void QuestChainComplete(IQuestable quest, QuestObjectView caller)
        {
            for (int i = 0; i < _questObjects.Length; i++)
            {
                if (_questObjects[i] == caller)
                {
                    if (i == 0 || _questControllers[i - 1].IsCompete)
                    {
                        _questTarget.QuestStepFinish(i);
                        quest.Completed -= OnQuestComplete;
                    }
                    else
                    {
                        _questControllers[i].ResetQuest();
                    }
                }
            }
        }

        private bool CheckStoryComplete()
        {
            foreach (var quest in _questControllers)
            {
                if (!quest.IsCompete)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

    }
}
