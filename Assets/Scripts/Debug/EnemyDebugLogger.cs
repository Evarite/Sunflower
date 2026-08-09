using Sunflower.Enemies;
using UnityEngine;

public class EnemyDebugLogger : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();

        _enemy.OnAttackPerformed += HandleAttack;
        _enemy.OnDied += HandleDied;
        _enemy.OnDespawned += HandleDespawned;
    }

    private void HandleAttack(ITargetable target)
    {
        string name = (target as Component) != null
            ? ((Component)target).gameObject.name
            : "unknown";

        Debug.Log($"[{_enemy.Data.enemyName}] атакует {name}");
    }

    private void HandleDied(Enemy enemy)
    {
        Debug.Log($"[{enemy.Data.enemyName}] умер");
    }

    private void HandleDespawned(Enemy enemy)
    {
        Debug.Log($"[{enemy.Data.enemyName}] исчез");
    }
}