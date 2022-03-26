using System;


namespace PiratesGame
{
    public sealed class SliderJointController : IUpdatable, IDisposable
    {

        #region Fields

        private MonoBehaviourManager _monoBehaviourManager;
        private SliderJointView _view;

        #endregion


        #region CodeLifeCycles

        public SliderJointController(MonoBehaviourManager monoBehaviourManager, SliderJointView view)
        {
            _monoBehaviourManager = monoBehaviourManager;
            _view = view;

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region IUpdatable

        public void LetFixedUpdate() { }

        public void LetUpdate()
        {
            
        }

        #endregion

        
        #region IDisposable

        public void Dispose()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
        }

        #endregion

    }
}
