namespace jcdcdev.Umbraco.Core.Web.Models.Manifests;

public class LocalizationManifest : IManifest
{
    public string Type => "localization";
    public required string Alias { get; set; }
    public required string Name { get; set; }
    public required MetaManifest Meta { get; set; }

    public class MetaManifest
    {
        public required string Culture { get; set; }


        /// <summary>
        /// A dictionary of localization sections, where each key is a section name and the value is a dictionary of key-value pairs.
        /// <para>
        /// <b>Important:</b> Umbraco only considers the <i>first</i> key in this dictionary.
        /// Any additional keys will be ignored.
        /// </para>
        /// </summary>
        public required Dictionary<string, Dictionary<string, string>> Localizations { get; set; }
    }
}
