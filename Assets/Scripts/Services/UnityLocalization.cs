using UnityEngine.Localization.Settings;

namespace root
{
    
    public class UnityLocalization : IUnityLocalization
    {

        public string Translate(string key, params object[] args)
        {
        string localizedString =
            LocalizationSettings.StringDatabase.GetLocalizedString(LocalizationSettings.StringDatabase.DefaultTable,
                key, arguments: args);
        return localizedString;
        }

    }
}