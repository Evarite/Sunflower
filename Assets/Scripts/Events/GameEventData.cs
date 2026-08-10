using Sunflower.Modifiers;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Event
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Sunflower/Game Event")]
    public class GameEventData : ScriptableObject
    {
        [Header("ID")]
        [SerializeField] private string _eventId;

        [Header("�������� ������")]
        public string eventName;

        [Header("������� ������ ����� (������)")]
        public float duration = 10f;

        [SerializeField]
        [Header("������ ������������� � ��������")]
        public List<ModifierData> modifiers = new List<ModifierData>();
  

        public string EventId => _eventId;
    }
}