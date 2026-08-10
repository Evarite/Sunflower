using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunflower.Enemies;
using Sunflower.Modifiers;
using Sunflower.Needs;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Sunflower.Enemies
{
    class ButterflyEnemy : Enemy
    {
        [SerializeField]
        private ModifierData _modifier;
        protected override void TryAttack()
        {
            _attackTimer -= Time.deltaTime;

            if (_attackTimer > 0f)
                return;

            _attackTimer = _data.attackInterval;

            if (NeedSystem.Instance == null)
                return;
            NeedSystem.Instance.ApplyModifier(_modifier,this);

            PerformeAttack(_currentTarget);
            AfterAttack(_currentTarget);
        }
    }
}
