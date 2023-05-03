using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireLike.Core.Weapons
{
    public class ProjectileWeapon : IWeapon
    {
        private ProjectileWeaponModel m_Model;
        private ProjectileWeaponView m_View;

        public ProjectileWeapon(ProjectileWeaponModel model, ProjectileWeaponView view)
        {
            m_Model = model;
            m_View = view;
        }

        public void Activate()
        {
            
        }

        public void Stop()
        {

        }

        public void Shoot(Vector3 taget)
        {
            
        }
    }
}