using TMPro;
using UnityEngine;

namespace Assets.Scrips
{
    public class GUICounter : MonoBehaviour
    {
        [SerializeField] private Scanner _scanner;
        [SerializeField] private Base _base;
        [SerializeField] private Warehouse _warehouse;

        [SerializeField] private TMP_Text _text;

        private void Update()
        {
            _text.text = $"Ресурсы: {_scanner.Resources}" +
                $"\nНайдены: {_base.ResourcesFound}" +
                $"\nСобраны {_warehouse.Resource}";
        }
    }
}