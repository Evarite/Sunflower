using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunflower.Enemies;

namespace Sunflower.Enemies
{
    class BeeEnemy : Enemy
    {
        protected override void AfterAttack(ITargetable target)
        {
            base.AfterAttack(target);
            Die();
        }
    }
}
