﻿using System;
using System.Collections.Generic;
using GoodAI.ToyWorld.Control;
using World.GameActors.GameObjects;

namespace Game
{
    public class AvatarController : IAvatarController
    {
        private readonly IAvatar m_avatar;
        private AvatarControls m_avatarControls;

        public AvatarController(IAvatar avatar)
        {
            m_avatar = avatar;
            m_avatarControls = new AvatarControls(int.MaxValue);
        }

        public void SetActions(IAvatarControls actions)
        {
            m_avatarControls.Update(actions);
            SetAvatarActionsControllable();
        }

        public IStats GetStats()
        {
            throw new NotImplementedException();
        }

        public string GetComment()
        {
            throw new NotImplementedException();
        }

        public void ResetControls()
        {
            m_avatarControls = new AvatarControls(int.MaxValue);
            m_avatar.ResetControls();
        }

        private void SetAvatarActionsControllable()
        {
            m_avatar.DesiredSpeed = m_avatarControls.DesiredSpeed;
            m_avatar.Interact = m_avatarControls.Interact;
            m_avatar.PickUp = m_avatarControls.PickUp;
            m_avatar.DesiredRotation = m_avatarControls.DesiredRotation;
            m_avatar.Use = m_avatarControls.Use;
            m_avatar.Fof = m_avatarControls.Fof;
        }
    }
}
