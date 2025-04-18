using System.Globalization;

namespace Blazor_MCP.Services
{
    public class LanguageService
    {
        public string strCultureCode = "en";
        public event Action? OnLanguageChanged;

        public LanguageService()
        {
            // Initialize with the default culture
            var culture = new CultureInfo(strCultureCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        public void ChangeCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            strCultureCode = cultureCode;

            OnLanguageChanged?.Invoke();
        }

        public string GetCurrentCulture()
        {
            return strCultureCode;
        }
    }
}
