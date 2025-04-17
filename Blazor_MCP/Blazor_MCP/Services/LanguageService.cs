using System.Globalization;

namespace Blazor_MCP.Services
{
    public class LanguageService
    {
        public event Action? OnLanguageChanged;

        public void ChangeCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            OnLanguageChanged?.Invoke();
        }
    }
}
