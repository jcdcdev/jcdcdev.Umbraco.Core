

using Umbraco.Cms.Core.Models;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.Core.Extensions;

public static class DataTypeExtensions
{
    private static readonly Guid[] Guids =
    [
        // Legacy editors
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.ContentPickerGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.MemberPickerGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.MediaPicker3Guid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.MediaPicker3MultipleGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.MediaPicker3SingleImageGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.MediaPicker3MultipleImagesGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.RelatedLinksGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.MemberGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.ImageCropperGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.TagsGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.ListViewContentGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.ListViewMediaGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.DatePickerWithTimeGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.ApprovedColorGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.DropdownMultipleGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.RadioboxGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.DatePickerGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.DropdownGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.CheckboxListGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.CheckboxGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.NumericGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.RichtextEditorGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.TextstringGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.TextareaGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.UploadGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.UploadVideoGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.UploadAudioGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.UploadArticleGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.UploadVectorGraphicsGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.LabelStringGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.LabelIntGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.LabelBigIntGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.LabelDateTimeGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.LabelTimeGuid,
        global::Umbraco.Cms.Core.Constants.DataTypes.Guids.LabelDecimalGuid
    ];

    private static readonly string[] Aliases =
    [
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.BlockList,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.CheckBoxList,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ColorPicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ColorPickerEyeDropper,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ContentPicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.DateTime,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.DropDownListFlexible,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Grid,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.BlockGrid,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ImageCropper,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Integer,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Decimal,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ListView,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MediaPicker3,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultipleMediaPicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MemberPicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MemberGroupPicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultiNodeTreePicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultipleTextstring,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Label,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PickerRelations,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.RadioButtonList,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Slider,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Tags,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TextBox,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TextArea,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Boolean,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MarkdownEditor,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.UserPicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.UploadField,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.EmailAddress,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.NestedContent,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultiUrlPicker,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TinyMce,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.RichText,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PlainString,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PlainJson,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PlainDecimal,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PlainInteger,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PlainDateTime,
        global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PlainTime
    ];

    public static bool IsUmbracoEditor(this IDataType dataType) => Aliases.InvariantContains(dataType.EditorAlias);

    public static bool IsInternalUmbracoEditor(this IDataType dataType) => Guids.Contains(dataType.Key);
}
