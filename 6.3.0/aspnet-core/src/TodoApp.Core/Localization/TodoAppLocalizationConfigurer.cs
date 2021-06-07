using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TodoApp.Localization
{
    public static class TodoAppLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TodoAppConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TodoAppLocalizationConfigurer).GetAssembly(),
                        "TodoApp.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
