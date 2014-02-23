using Wp8_yeni_launcher_ve_chooserlar.Resources;

namespace Wp8_yeni_launcher_ve_chooserlar
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}