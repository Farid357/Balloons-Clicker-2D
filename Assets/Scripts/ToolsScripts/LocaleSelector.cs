using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Clicker.Localization
{
    public sealed class LocaleSelector : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;

        private IEnumerator Start()
        {
            yield return LocalizationSettings.InitializationOperation;
            var options = new List<TMP_Dropdown.OptionData>();
            int selected = 0;

            for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
            {
                var locale = LocalizationSettings.AvailableLocales.Locales[i];

                if (LocalizationSettings.SelectedLocale == locale)
                    selected = i;

                options.Add(new TMP_Dropdown.OptionData(LocalizationSettings.AvailableLocales.Locales[i].name));
            }
            _dropdown.options = options;
            _dropdown.value = selected;
            _dropdown.onValueChanged.AddListener(Select);
        }

        private void Select(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }
    }
}
