using System;
using System.Collections.Generic;
using UnityEngine;


namespace PiratesGame
{
    public sealed class RigidbodyContactChecker : IUpdatable, IDisposable
    {

        #region Fields

        private const float COLLISION_FACTOR = 0.5f;

        private MonoBehaviourManager _monoBehaviourManager;

        private Rigidbody2D _rigidbody;
        private List<ContactPoint2D> _contacts;

        #endregion


        #region Properties

        public bool LeftContact { get; private set; }
        public bool RightContact { get; private set; }
        public bool BottomContact { get; private set; }

        #endregion


        #region CodeLifeCycles

        public RigidbodyContactChecker(Rigidbody2D rigidbody, MonoBehaviourManager monoBehaviourManager)
        {
            _monoBehaviourManager = monoBehaviourManager;
            _rigidbody = rigidbody;
            _contacts = new List<ContactPoint2D>();

            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.AddCandidateUpdate);
        }

        #endregion


        #region Methods

        private void CheckContacts()
        {
            LeftContact = false;
            RightContact = false;
            BottomContact = false;

            _rigidbody.GetContacts(_contacts);
            foreach (ContactPoint2D contactPoint in _contacts)
            {
                if (contactPoint.normal.y > COLLISION_FACTOR)
                {
                    BottomContact = true;
                }
                if (contactPoint.rigidbody == null)
                {
                    if (contactPoint.normal.x > COLLISION_FACTOR)
                    {
                        LeftContact = true;
                    }
                    else
                    {
                        if (contactPoint.normal.x < -COLLISION_FACTOR)
                        {
                            RightContact = true;
                        }
                    }
                }
            }
        }

        #endregion


        #region IUpdatable

        public void LetUpdate()
        {
            CheckContacts();
        }

        public void LetFixedUpdate() { }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            _monoBehaviourManager.ChangeUpdateList(this, UpdatableTypes.RemoveCandidateUpdate);
        }

        #endregion

    }
}
