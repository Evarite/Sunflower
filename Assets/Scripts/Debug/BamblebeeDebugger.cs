using Sunflower.Enemies;
using UnityEngine;

public class BamblebeeDebugger : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();

        if (_enemy == null)
        {
            Debug.LogError("EnemyDebugLogger: на объекте нет Enemy", gameObject);
            enabled = false;
            return;
        }

        _enemy.OnAttackPerformed += HandleAttack;
        _enemy.OnProvoked += HandleProvoked;
        _enemy.OnDied += HandleDied;
        _enemy.OnDespawned += HandleDespawned;
    }

    private void OnDestroy()
    {
        if (_enemy == null)
            return;

        _enemy.OnAttackPerformed -= HandleAttack;
        _enemy.OnProvoked -= HandleProvoked;
        _enemy.OnDied -= HandleDied;
        _enemy.OnDespawned -= HandleDespawned;
    }

    private void HandleAttack(ITargetable target)
    {
        string name = target is Component component
            ? component.gameObject.name
            : "unknown";

        Debug.Log($"[{_enemy.Data.enemyName}] атакует {name}");
    }

    private void HandleProvoked(Enemy enemy)
    {
        Debug.Log($"[{enemy.Data.enemyName}] разозлился");
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