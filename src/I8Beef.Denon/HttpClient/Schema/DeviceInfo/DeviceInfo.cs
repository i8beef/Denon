using System.Xml.Serialization;
using System.Collections.Generic;

namespace I8Beef.Denon.HttpClient.Schema.DeviceInfo
{
    [XmlRoot(ElementName = "lists")]
    public class DeviceInfoLists
    {
        [XmlElement(ElementName = "ItemType")]
        public string ItemType { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "MenuName")]
        public string MenuName { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "IconID")]
        public string IconID { get; set; }
        [XmlElement(ElementName = "lists")]
        public List<DeviceInfoLists> Lists { get; set; }
        [XmlElement(ElementName = "value")]
        public List<string> Value { get; set; }
    }

    [XmlRoot(ElementName = "Menu")]
    public class Menu
    {
        [XmlElement(ElementName = "lists")]
        public List<DeviceInfoLists> Lists { get; set; }
    }

    [XmlRoot(ElementName = "Language")]
    public class Language
    {
        [XmlElement(ElementName = "lists")]
        public DeviceInfoLists Lists { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "NetLink")]
    public class NetLink
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "ClockAdjust")]
    public class ClockAdjust
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "Functions")]
    public class Functions
    {
        [XmlElement(ElementName = "AllZoneSleep")]
        public string AllZoneSleep { get; set; }
        [XmlElement(ElementName = "GetECO")]
        public string GetECO { get; set; }
        [XmlElement(ElementName = "GetECOMeter")]
        public string GetECOMeter { get; set; }
        [XmlElement(ElementName = "GetAutoStandby")]
        public string GetAutoStandby { get; set; }
        [XmlElement(ElementName = "SetECOMode")]
        public string SetECOMode { get; set; }
        [XmlElement(ElementName = "SetECOPwOnDefault")]
        public string SetECOPwOnDefault { get; set; }
        [XmlElement(ElementName = "SetECODisplay")]
        public string SetECODisplay { get; set; }
        [XmlElement(ElementName = "SetAutoStandby")]
        public string SetAutoStandby { get; set; }
        [XmlElement(ElementName = "GetToneControl")]
        public string GetToneControl { get; set; }
        [XmlElement(ElementName = "SetToneControl")]
        public string SetToneControl { get; set; }
        [XmlElement(ElementName = "GetDialogLevel")]
        public string GetDialogLevel { get; set; }
        [XmlElement(ElementName = "SetDialogLevel")]
        public string SetDialogLevel { get; set; }
        [XmlElement(ElementName = "GetSubwooferLevel")]
        public string GetSubwooferLevel { get; set; }
        [XmlElement(ElementName = "SetSubwooferLevel")]
        public string SetSubwooferLevel { get; set; }
        [XmlElement(ElementName = "GetChLevel")]
        public string GetChLevel { get; set; }
        [XmlElement(ElementName = "SetChLevel")]
        public string SetChLevel { get; set; }
        [XmlElement(ElementName = "GetAllZoneStereo")]
        public string GetAllZoneStereo { get; set; }
        [XmlElement(ElementName = "SetAllZoneStereo")]
        public string SetAllZoneStereo { get; set; }
        [XmlElement(ElementName = "SetAllZoneVolume")]
        public string SetAllZoneVolume { get; set; }
        [XmlElement(ElementName = "GetDimmer")]
        public string GetDimmer { get; set; }
        [XmlElement(ElementName = "SetDimmer")]
        public string SetDimmer { get; set; }
        [XmlElement(ElementName = "GetSlideshow")]
        public string GetSlideshow { get; set; }
        [XmlElement(ElementName = "SetSlideshow")]
        public string SetSlideshow { get; set; }
        [XmlElement(ElementName = "GetSlideshowInterval")]
        public string GetSlideshowInterval { get; set; }
        [XmlElement(ElementName = "SetSlideshowInterval")]
        public string SetSlideshowInterval { get; set; }
        [XmlElement(ElementName = "DispFriendlyNameCandidate")]
        public string DispFriendlyNameCandidate { get; set; }
        [XmlElement(ElementName = "GetPictureMode")]
        public string GetPictureMode { get; set; }
        [XmlElement(ElementName = "SetPictureMode")]
        public string SetPictureMode { get; set; }
        [XmlElement(ElementName = "GetVideoSelect")]
        public string GetVideoSelect { get; set; }
        [XmlElement(ElementName = "SetVideoSelect")]
        public string SetVideoSelect { get; set; }
        [XmlElement(ElementName = "GetZoneName")]
        public string GetZoneName { get; set; }
        [XmlElement(ElementName = "SetZoneName")]
        public string SetZoneName { get; set; }
        [XmlElement(ElementName = "SetZoneNameDefault")]
        public string SetZoneNameDefault { get; set; }
        [XmlElement(ElementName = "GetStatus")]
        public string GetStatus { get; set; }
        [XmlElement(ElementName = "FavoriteCall")]
        public string FavoriteCall { get; set; }
        [XmlElement(ElementName = "SetMaxVolume")]
        public string SetMaxVolume { get; set; }
        [XmlElement(ElementName = "SourceSelect")]
        public string SourceSelect { get; set; }
        [XmlElement(ElementName = "GetRenameSource")]
        public string GetRenameSource { get; set; }
        [XmlElement(ElementName = "GetDeleteSource")]
        public string GetDeleteSource { get; set; }
        [XmlElement(ElementName = "ChangeSurroundMode")]
        public string ChangeSurroundMode { get; set; }
        [XmlElement(ElementName = "ChangeRestorerMode")]
        public string ChangeRestorerMode { get; set; }
        [XmlElement(ElementName = "GetQuickSelectName")]
        public string GetQuickSelectName { get; set; }
        [XmlElement(ElementName = "SetQuickSelectName")]
        public string SetQuickSelectName { get; set; }
        [XmlElement(ElementName = "SetQuickSelectNameDefault")]
        public string SetQuickSelectNameDefault { get; set; }
        [XmlElement(ElementName = "SetQuickSelectMemory")]
        public string SetQuickSelectMemory { get; set; }
        [XmlElement(ElementName = "SetQuickSelect")]
        public string SetQuickSelect { get; set; }
        [XmlElement(ElementName = "SelectBand")]
        public string SelectBand { get; set; }
        [XmlElement(ElementName = "GetPresetList")]
        public string GetPresetList { get; set; }
        [XmlElement(ElementName = "PresetCall")]
        public string PresetCall { get; set; }
        [XmlElement(ElementName = "PresetUpDown")]
        public string PresetUpDown { get; set; }
        [XmlElement(ElementName = "TuneUpDown")]
        public string TuneUpDown { get; set; }
        [XmlElement(ElementName = "FreqDirect")]
        public string FreqDirect { get; set; }
        [XmlElement(ElementName = "GetPresetListPOST")]
        public string GetPresetListPOST { get; set; }
        [XmlElement(ElementName = "SetTunerTuneMode")]
        public string SetTunerTuneMode { get; set; }
        [XmlElement(ElementName = "SetPresetMemory")]
        public string SetPresetMemory { get; set; }
        [XmlElement(ElementName = "SetAutoPreset")]
        public string SetAutoPreset { get; set; }
        [XmlElement(ElementName = "SetPresetSkip")]
        public string SetPresetSkip { get; set; }
        [XmlElement(ElementName = "SetPresetName")]
        public string SetPresetName { get; set; }
        [XmlElement(ElementName = "SetPresetNameDefault")]
        public string SetPresetNameDefault { get; set; }
        [XmlElement(ElementName = "OpeFuncSet")]
        public string OpeFuncSet { get; set; }
        [XmlElement(ElementName = "DeleteSource")]
        public string DeleteSource { get; set; }
        [XmlElement(ElementName = "BrowseScroll")]
        public string BrowseScroll { get; set; }
        [XmlElement(ElementName = "GoToPV")]
        public string GoToPV { get; set; }
        [XmlElement(ElementName = "AddToPreset")]
        public string AddToPreset { get; set; }
        [XmlElement(ElementName = "AddToFavorite")]
        public string AddToFavorite { get; set; }
        [XmlElement(ElementName = "PbFuncSet")]
        public string PbFuncSet { get; set; }
        [XmlElement(ElementName = "PbModeSet")]
        public string PbModeSet { get; set; }
        [XmlElement(ElementName = "SupportLogin")]
        public string SupportLogin { get; set; }
        [XmlElement(ElementName = "Context")]
        public string Context { get; set; }
        [XmlElement(ElementName = "GaplessPb")]
        public string GaplessPb { get; set; }
        [XmlElement(ElementName = "Seek")]
        public string Seek { get; set; }
        [XmlElement(ElementName = "PicPlayView")]
        public string PicPlayView { get; set; }
        [XmlElement(ElementName = "TextSearch")]
        public string TextSearch { get; set; }
    }

    [XmlRoot(ElementName = "SleepTimer")]
    public class SleepTimer
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "MaxTimeMin")]
        public string MaxTimeMin { get; set; }
        [XmlElement(ElementName = "StepTimeMin")]
        public string StepTimeMin { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "WakeupTimer")]
    public class WakeupTimer
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "PartyMode")]
    public class PartyMode
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "Version")]
        public string Version { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "BatteryMode")]
    public class BatteryMode
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "DeviceColor")]
    public class DeviceColor
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "Color")]
        public string Color { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "List")]
    public class List
    {
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "Value")]
        public List<Value> Value { get; set; }
        [XmlElement(ElementName = "Source")]
        public List<Source> Source { get; set; }
        [XmlElement(ElementName = "Mode")]
        public List<Mode> Mode { get; set; }
    }

    [XmlRoot(ElementName = "AutoStandby")]
    public class AutoStandby
    {
        [XmlElement(ElementName = "Zone")]
        public string Zone { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "ECO")]
    public class ECO
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "FuncSet")]
    public class FuncSet
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "ToneControlSet_AVR")]
    public class ToneControlSet_AVR
    {
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "BassMin")]
        public string BassMin { get; set; }
        [XmlElement(ElementName = "BassMax")]
        public string BassMax { get; set; }
        [XmlElement(ElementName = "BassDefault")]
        public string BassDefault { get; set; }
        [XmlElement(ElementName = "BassStep")]
        public string BassStep { get; set; }
        [XmlElement(ElementName = "TrebleMin")]
        public string TrebleMin { get; set; }
        [XmlElement(ElementName = "TrebleMax")]
        public string TrebleMax { get; set; }
        [XmlElement(ElementName = "TrebleDefault")]
        public string TrebleDefault { get; set; }
        [XmlElement(ElementName = "TrebleStep")]
        public string TrebleStep { get; set; }
    }

    [XmlRoot(ElementName = "ToneControl")]
    public class ToneControl
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncSet")]
        public FuncSet FuncSet { get; set; }
        [XmlElement(ElementName = "ToneControlSet_AVR")]
        public ToneControlSet_AVR ToneControlSet_AVR { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
    }

    [XmlRoot(ElementName = "DialogLevel")]
    public class DialogLevel
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "MinRange")]
        public string MinRange { get; set; }
        [XmlElement(ElementName = "MaxRange")]
        public string MaxRange { get; set; }
        [XmlElement(ElementName = "DefaultValue")]
        public string DefaultValue { get; set; }
        [XmlElement(ElementName = "Step")]
        public string Step { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "SubwooferLevel")]
    public class SubwooferLevel
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "SubwooferNum")]
        public string SubwooferNum { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "MinRange")]
        public string MinRange { get; set; }
        [XmlElement(ElementName = "MaxRange")]
        public string MaxRange { get; set; }
        [XmlElement(ElementName = "DefaultValue")]
        public string DefaultValue { get; set; }
        [XmlElement(ElementName = "Step")]
        public string Step { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "Ch")]
    public class Ch
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "MinRange")]
        public string MinRange { get; set; }
        [XmlElement(ElementName = "MaxRange")]
        public string MaxRange { get; set; }
        [XmlElement(ElementName = "DefaultValue")]
        public string DefaultValue { get; set; }
        [XmlElement(ElementName = "Step")]
        public string Step { get; set; }
    }

    [XmlRoot(ElementName = "ChLists")]
    public class ChLists
    {
        [XmlElement(ElementName = "Ch")]
        public List<Ch> Ch { get; set; }
    }

    [XmlRoot(ElementName = "ChannelLevel")]
    public class ChannelLevel
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ChLists")]
        public ChLists ChLists { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "SoundModeList")]
    public class SoundModeList
    {
        [XmlElement(ElementName = "Name")]
        public List<string> Name { get; set; }
    }

    [XmlRoot(ElementName = "AllZoneStereo")]
    public class AllZoneStereo
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "SoundModeList")]
        public SoundModeList SoundModeList { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "UserManualViewer")]
    public class UserManualViewer
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "Value")]
    public class Value
    {
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "CmdNo")]
        public string CmdNo { get; set; }
        [XmlElement(ElementName = "Zone")]
        public string Zone { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
    }

    [XmlRoot(ElementName = "Dimmer")]
    public class Dimmer
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "FrontDisplay")]
    public class FrontDisplay
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "Dimmer")]
        public Dimmer Dimmer { get; set; }
    }

    [XmlRoot(ElementName = "Slideshow")]
    public class Slideshow
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "SlideshowInterval")]
    public class SlideshowInterval
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "GetNetworkInfo")]
    public class GetNetworkInfo
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Commands")]
    public class Commands
    {
        [XmlElement(ElementName = "GetNetworkInfo")]
        public GetNetworkInfo GetNetworkInfo { get; set; }
        [XmlElement(ElementName = "SetZoneNameDefault")]
        public SetZoneNameDefault SetZoneNameDefault { get; set; }
        [XmlElement(ElementName = "GetRestorerMode")]
        public GetRestorerMode GetRestorerMode { get; set; }
        [XmlElement(ElementName = "SetRestorerMode")]
        public SetRestorerMode SetRestorerMode { get; set; }
        [XmlElement(ElementName = "GetHdmiSetup")]
        public GetHdmiSetup GetHdmiSetup { get; set; }
        [XmlElement(ElementName = "SetHdmiSetup")]
        public SetHdmiSetup SetHdmiSetup { get; set; }
        [XmlElement(ElementName = "GetEQSetting")]
        public GetEQSetting GetEQSetting { get; set; }
        [XmlElement(ElementName = "SetEQSetting")]
        public SetEQSetting SetEQSetting { get; set; }
        [XmlElement(ElementName = "GetEQAdjustChList")]
        public GetEQAdjustChList GetEQAdjustChList { get; set; }
        [XmlElement(ElementName = "GetEQParameter")]
        public GetEQParameter GetEQParameter { get; set; }
        [XmlElement(ElementName = "SetEQParameter")]
        public SetEQParameter SetEQParameter { get; set; }
        [XmlElement(ElementName = "GetEQOtherFunc")]
        public GetEQOtherFunc GetEQOtherFunc { get; set; }
        [XmlElement(ElementName = "SetEQOtherFunc")]
        public SetEQOtherFunc SetEQOtherFunc { get; set; }
        [XmlElement(ElementName = "GetAudyssey")]
        public GetAudyssey GetAudyssey { get; set; }
        [XmlElement(ElementName = "GetAudysseyEQCurveType")]
        public GetAudysseyEQCurveType GetAudysseyEQCurveType { get; set; }
        [XmlElement(ElementName = "SetAudyssey")]
        public SetAudyssey SetAudyssey { get; set; }
        [XmlElement(ElementName = "GetSurroundParameter")]
        public GetSurroundParameter GetSurroundParameter { get; set; }
        [XmlElement(ElementName = "SetSurroundParameter")]
        public SetSurroundParameter SetSurroundParameter { get; set; }
        [XmlElement(ElementName = "GetAudioDelay")]
        public GetAudioDelay GetAudioDelay { get; set; }
        [XmlElement(ElementName = "SetAudioDelay")]
        public SetAudioDelay SetAudioDelay { get; set; }
        [XmlElement(ElementName = "GetExternalContol")]
        public GetExternalContol GetExternalContol { get; set; }
        [XmlElement(ElementName = "SetExternalContol")]
        public SetExternalContol SetExternalContol { get; set; }
        [XmlElement(ElementName = "GetSourceRename")]
        public GetSourceRename GetSourceRename { get; set; }
        [XmlElement(ElementName = "SetSourceRename")]
        public SetSourceRename SetSourceRename { get; set; }
        [XmlElement(ElementName = "SetSourceRenameDefault")]
        public SetSourceRenameDefault SetSourceRenameDefault { get; set; }
        [XmlElement(ElementName = "GetLRchLevel")]
        public GetLRchLevel GetLRchLevel { get; set; }
        [XmlElement(ElementName = "SetLRchLevel")]
        public SetLRchLevel SetLRchLevel { get; set; }
        [XmlElement(ElementName = "GetUpdateInfo")]
        public GetUpdateInfo GetUpdateInfo { get; set; }
        [XmlElement(ElementName = "SetCheckUpdate")]
        public SetCheckUpdate SetCheckUpdate { get; set; }
        [XmlElement(ElementName = "SetUpdate")]
        public SetUpdate SetUpdate { get; set; }
        [XmlElement(ElementName = "GetSoundMode")]
        public GetSoundMode GetSoundMode { get; set; }
        [XmlElement(ElementName = "SetSoundMode")]
        public SetSoundMode SetSoundMode { get; set; }
        [XmlElement(ElementName = "GetSoundModeList")]
        public GetSoundModeList GetSoundModeList { get; set; }
        [XmlElement(ElementName = "SetSoundModeList")]
        public SetSoundModeList SetSoundModeList { get; set; }
        [XmlElement(ElementName = "GetInputSignal")]
        public GetInputSignal GetInputSignal { get; set; }
        [XmlElement(ElementName = "GetActiveSpeaker")]
        public GetActiveSpeaker GetActiveSpeaker { get; set; }
        [XmlElement(ElementName = "GetVideoInfo")]
        public GetVideoInfo GetVideoInfo { get; set; }
        [XmlElement(ElementName = "GetAudioInfo")]
        public GetAudioInfo GetAudioInfo { get; set; }
        [XmlElement(ElementName = "GetAudyssyInfo")]
        public GetAudyssyInfo GetAudyssyInfo { get; set; }
        [XmlElement(ElementName = "GetFilteredFavoriteList")]
        public GetFilteredFavoriteList GetFilteredFavoriteList { get; set; }
        [XmlElement(ElementName = "SetFilteredFavoritePlay")]
        public SetFilteredFavoritePlay SetFilteredFavoritePlay { get; set; }
    }

    [XmlRoot(ElementName = "NetworkInfo")]
    public class NetworkInfo
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "PictureMode")]
    public class PictureMode
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "VideoSelect")]
    public class VideoSelect
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "SetZoneNameDefault")]
    public class SetZoneNameDefault
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ZoneRename")]
    public class ZoneRename
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "GetRestorerMode")]
    public class GetRestorerMode
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetRestorerMode")]
    public class SetRestorerMode
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Restorer")]
    public class Restorer
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "HdmiAudioOut")]
    public class HdmiAudioOut
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "HdmiVideoOut")]
    public class HdmiVideoOut
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "GetHdmiSetup")]
    public class GetHdmiSetup
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetHdmiSetup")]
    public class SetHdmiSetup
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "HdmiSetup")]
    public class HdmiSetup
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "HdmiAudioOut")]
        public HdmiAudioOut HdmiAudioOut { get; set; }
        [XmlElement(ElementName = "HdmiVideoOut")]
        public HdmiVideoOut HdmiVideoOut { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "SpeakerSelection")]
    public class SpeakerSelection
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "EnableAllChList")]
    public class EnableAllChList
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "EnableLRChList")]
    public class EnableLRChList
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "EnableEachChList")]
    public class EnableEachChList
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "EQBand")]
    public class EQBand
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "EQAdjustDB")]
    public class EQAdjustDB
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "MinValue")]
        public string MinValue { get; set; }
        [XmlElement(ElementName = "MaxValue")]
        public string MaxValue { get; set; }
        [XmlElement(ElementName = "StepValue")]
        public string StepValue { get; set; }
    }

    [XmlRoot(ElementName = "GetEQSetting")]
    public class GetEQSetting
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetEQSetting")]
    public class SetEQSetting
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetEQAdjustChList")]
    public class GetEQAdjustChList
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetEQParameter")]
    public class GetEQParameter
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetEQParameter")]
    public class SetEQParameter
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetEQOtherFunc")]
    public class GetEQOtherFunc
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetEQOtherFunc")]
    public class SetEQOtherFunc
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GraphicEQ")]
    public class GraphicEQ
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "SpeakerSelection")]
        public SpeakerSelection SpeakerSelection { get; set; }
        [XmlElement(ElementName = "EnableAllChList")]
        public EnableAllChList EnableAllChList { get; set; }
        [XmlElement(ElementName = "EnableLRChList")]
        public EnableLRChList EnableLRChList { get; set; }
        [XmlElement(ElementName = "EnableEachChList")]
        public EnableEachChList EnableEachChList { get; set; }
        [XmlElement(ElementName = "EQBand")]
        public EQBand EQBand { get; set; }
        [XmlElement(ElementName = "EQAdjustDB")]
        public EQAdjustDB EQAdjustDB { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "MultEq")]
    public class MultEq
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "DynamicEq")]
    public class DynamicEq
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "DynamicVolume")]
    public class DynamicVolume
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "GetAudyssey")]
    public class GetAudyssey
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetAudysseyEQCurveType")]
    public class GetAudysseyEQCurveType
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetAudyssey")]
    public class SetAudyssey
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Audyssey")]
    public class Audyssey
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "MultEq")]
        public MultEq MultEq { get; set; }
        [XmlElement(ElementName = "DynamicEq")]
        public DynamicEq DynamicEq { get; set; }
        [XmlElement(ElementName = "DynamicVolume")]
        public DynamicVolume DynamicVolume { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "CinemaEq")]
    public class CinemaEq
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "GetSurroundParameter")]
    public class GetSurroundParameter
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetSurroundParameter")]
    public class SetSurroundParameter
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SurroundParameter")]
    public class SurroundParameter
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "CinemaEq")]
        public CinemaEq CinemaEq { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "GetAudioDelay")]
    public class GetAudioDelay
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetAudioDelay")]
    public class SetAudioDelay
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "AudioDelay")]
    public class AudioDelay
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "MinValue")]
        public string MinValue { get; set; }
        [XmlElement(ElementName = "MaxValue")]
        public string MaxValue { get; set; }
        [XmlElement(ElementName = "StepValue")]
        public string StepValue { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "GetExternalContol")]
    public class GetExternalContol
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetExternalContol")]
    public class SetExternalContol
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ExternalContol")]
    public class ExternalContol
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "GetSourceRename")]
    public class GetSourceRename
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetSourceRename")]
    public class SetSourceRename
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetSourceRenameDefault")]
    public class SetSourceRenameDefault
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SourceRename")]
    public class SourceRename
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "LchLevel")]
    public class LchLevel
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "MinValue")]
        public string MinValue { get; set; }
        [XmlElement(ElementName = "MaxValue")]
        public string MaxValue { get; set; }
        [XmlElement(ElementName = "StepValue")]
        public string StepValue { get; set; }
    }

    [XmlRoot(ElementName = "RchLevel")]
    public class RchLevel
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "MinValue")]
        public string MinValue { get; set; }
        [XmlElement(ElementName = "MaxValue")]
        public string MaxValue { get; set; }
        [XmlElement(ElementName = "StepValue")]
        public string StepValue { get; set; }
    }

    [XmlRoot(ElementName = "GetLRchLevel")]
    public class GetLRchLevel
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetLRchLevel")]
    public class SetLRchLevel
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Zone2Setup")]
    public class Zone2Setup
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "LchLevel")]
        public LchLevel LchLevel { get; set; }
        [XmlElement(ElementName = "RchLevel")]
        public RchLevel RchLevel { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "GetUpdateInfo")]
    public class GetUpdateInfo
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetCheckUpdate")]
    public class SetCheckUpdate
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetUpdate")]
    public class SetUpdate
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "FirmwareUpdate")]
    public class FirmwareUpdate
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "Genre")]
    public class Genre
    {
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "GetSoundMode")]
    public class GetSoundMode
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetSoundMode")]
    public class SetSoundMode
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetSoundModeList")]
    public class GetSoundModeList
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetSoundModeList")]
    public class SetSoundModeList
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SoundMode")]
    public class SoundMode
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "Genre")]
        public Genre Genre { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "GetInputSignal")]
    public class GetInputSignal
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetActiveSpeaker")]
    public class GetActiveSpeaker
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetVideoInfo")]
    public class GetVideoInfo
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetAudioInfo")]
    public class GetAudioInfo
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "GetAudyssyInfo")]
    public class GetAudyssyInfo
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "StatusInfo")]
    public class StatusInfo
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "Sp")]
    public class Sp
    {
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "CmdNo")]
        public string CmdNo { get; set; }
    }

    [XmlRoot(ElementName = "SpList")]
    public class SpList
    {
        [XmlElement(ElementName = "Sp")]
        public List<Sp> Sp { get; set; }
    }

    [XmlRoot(ElementName = "SpeakerAB")]
    public class SpeakerAB
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "SpList")]
        public SpList SpList { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "AutoSetupMenuOff")]
    public class AutoSetupMenuOff
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
    }

    [XmlRoot(ElementName = "Setup")]
    public class Setup
    {
        [XmlElement(ElementName = "Language")]
        public Language Language { get; set; }
        [XmlElement(ElementName = "NetLink")]
        public NetLink NetLink { get; set; }
        [XmlElement(ElementName = "ClockAdjust")]
        public ClockAdjust ClockAdjust { get; set; }
        [XmlElement(ElementName = "SleepTimer")]
        public SleepTimer SleepTimer { get; set; }
        [XmlElement(ElementName = "WakeupTimer")]
        public WakeupTimer WakeupTimer { get; set; }
        [XmlElement(ElementName = "PartyMode")]
        public PartyMode PartyMode { get; set; }
        [XmlElement(ElementName = "BatteryMode")]
        public BatteryMode BatteryMode { get; set; }
        [XmlElement(ElementName = "DeviceColor")]
        public DeviceColor DeviceColor { get; set; }
        [XmlElement(ElementName = "ECO")]
        public ECO ECO { get; set; }
        [XmlElement(ElementName = "ToneControl")]
        public ToneControl ToneControl { get; set; }
        [XmlElement(ElementName = "DialogLevel")]
        public DialogLevel DialogLevel { get; set; }
        [XmlElement(ElementName = "SubwooferLevel")]
        public SubwooferLevel SubwooferLevel { get; set; }
        [XmlElement(ElementName = "ChannelLevel")]
        public ChannelLevel ChannelLevel { get; set; }
        [XmlElement(ElementName = "AllZoneStereo")]
        public AllZoneStereo AllZoneStereo { get; set; }
        [XmlElement(ElementName = "UserManualViewer")]
        public UserManualViewer UserManualViewer { get; set; }
        [XmlElement(ElementName = "FrontDisplay")]
        public FrontDisplay FrontDisplay { get; set; }
        [XmlElement(ElementName = "Slideshow")]
        public Slideshow Slideshow { get; set; }
        [XmlElement(ElementName = "SlideshowInterval")]
        public SlideshowInterval SlideshowInterval { get; set; }
        [XmlElement(ElementName = "NetworkInfo")]
        public NetworkInfo NetworkInfo { get; set; }
        [XmlElement(ElementName = "PictureMode")]
        public PictureMode PictureMode { get; set; }
        [XmlElement(ElementName = "VideoSelect")]
        public VideoSelect VideoSelect { get; set; }
        [XmlElement(ElementName = "ZoneRename")]
        public ZoneRename ZoneRename { get; set; }
        [XmlElement(ElementName = "Restorer")]
        public Restorer Restorer { get; set; }
        [XmlElement(ElementName = "HdmiSetup")]
        public HdmiSetup HdmiSetup { get; set; }
        [XmlElement(ElementName = "GraphicEQ")]
        public GraphicEQ GraphicEQ { get; set; }
        [XmlElement(ElementName = "Audyssey")]
        public Audyssey Audyssey { get; set; }
        [XmlElement(ElementName = "SurroundParameter")]
        public SurroundParameter SurroundParameter { get; set; }
        [XmlElement(ElementName = "AudioDelay")]
        public AudioDelay AudioDelay { get; set; }
        [XmlElement(ElementName = "ExternalContol")]
        public ExternalContol ExternalContol { get; set; }
        [XmlElement(ElementName = "SourceRename")]
        public SourceRename SourceRename { get; set; }
        [XmlElement(ElementName = "Zone2Setup")]
        public Zone2Setup Zone2Setup { get; set; }
        [XmlElement(ElementName = "FirmwareUpdate")]
        public FirmwareUpdate FirmwareUpdate { get; set; }
        [XmlElement(ElementName = "SoundMode")]
        public SoundMode SoundMode { get; set; }
        [XmlElement(ElementName = "StatusInfo")]
        public StatusInfo StatusInfo { get; set; }
        [XmlElement(ElementName = "SpeakerAB")]
        public SpeakerAB SpeakerAB { get; set; }
        [XmlElement(ElementName = "AutoSetupMenuOff")]
        public AutoSetupMenuOff AutoSetupMenuOff { get; set; }
    }

    [XmlRoot(ElementName = "Clock")]
    public class Clock
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "AllZonePower")]
    public class AllZonePower
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "AllZoneMute")]
    public class AllZoneMute
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "Favorites")]
    public class Favorites
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "MaxFavorites")]
        public string MaxFavorites { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "FilteringSource")]
        public FilteringSource FilteringSource { get; set; }
        [XmlElement(ElementName = "Commands")]
        public Commands Commands { get; set; }
    }

    [XmlRoot(ElementName = "Operation")]
    public class Operation
    {
        [XmlElement(ElementName = "Clock")]
        public Clock Clock { get; set; }
        [XmlElement(ElementName = "AllZonePower")]
        public AllZonePower AllZonePower { get; set; }
        [XmlElement(ElementName = "AllZoneMute")]
        public AllZoneMute AllZoneMute { get; set; }
        [XmlElement(ElementName = "Favorites")]
        public Favorites Favorites { get; set; }
        [XmlElement(ElementName = "Cursor")]
        public Cursor Cursor { get; set; }
        [XmlElement(ElementName = "QuickSelect")]
        public QuickSelect QuickSelect { get; set; }
        [XmlElement(ElementName = "TunerOperation")]
        public TunerOperation TunerOperation { get; set; }
        [XmlElement(ElementName = "BdOperation")]
        public BdOperation BdOperation { get; set; }
        [XmlElement(ElementName = "CdOperation")]
        public CdOperation CdOperation { get; set; }
        [XmlElement(ElementName = "DockOperation")]
        public DockOperation DockOperation { get; set; }
        [XmlElement(ElementName = "PartyZone")]
        public PartyZone PartyZone { get; set; }
    }

    [XmlRoot(ElementName = "DeviceCapabilities")]
    public class DeviceCapabilities
    {
        [XmlElement(ElementName = "Menu")]
        public Menu Menu { get; set; }
        [XmlElement(ElementName = "Setup")]
        public Setup Setup { get; set; }
        [XmlElement(ElementName = "Operation")]
        public Operation Operation { get; set; }
    }

    [XmlRoot(ElementName = "Zone")]
    public class Zone
    {
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
    }

    [XmlRoot(ElementName = "Shortcut")]
    public class Shortcut
    {
        [XmlElement(ElementName = "Category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
    }

    [XmlRoot(ElementName = "EntryList")]
    public class EntryList
    {
        [XmlElement(ElementName = "Shortcut")]
        public List<Shortcut> Shortcut { get; set; }
    }

    [XmlRoot(ElementName = "DefaultList")]
    public class DefaultList
    {
        [XmlElement(ElementName = "Shortcut")]
        public List<Shortcut> Shortcut { get; set; }
    }

    [XmlRoot(ElementName = "ShortcutControl")]
    public class ShortcutControl
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "EntryList")]
        public EntryList EntryList { get; set; }
        [XmlElement(ElementName = "DefaultList")]
        public DefaultList DefaultList { get; set; }
    }

    [XmlRoot(ElementName = "Power")]
    public class Power
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
    }

    [XmlRoot(ElementName = "Param")]
    public class Param
    {
        [XmlElement(ElementName = "Absolute")]
        public string Absolute { get; set; }
        [XmlElement(ElementName = "Relative")]
        public string Relative { get; set; }
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "MaxVolumeList")]
    public class MaxVolumeList
    {
        [XmlElement(ElementName = "Param")]
        public List<Param> Param { get; set; }
    }

    [XmlRoot(ElementName = "Volume")]
    public class Volume
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "MaxValue")]
        public string MaxValue { get; set; }
        [XmlElement(ElementName = "StepValue")]
        public string StepValue { get; set; }
        [XmlElement(ElementName = "MaxVolumeList")]
        public MaxVolumeList MaxVolumeList { get; set; }
        [XmlElement(ElementName = "DefaultMaxVolumeValue")]
        public string DefaultMaxVolumeValue { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "Mute")]
    public class Mute
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
    }

    [XmlRoot(ElementName = "Source")]
    public class Source
    {
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "DefaultName")]
        public string DefaultName { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "GroupNo")]
        public string GroupNo { get; set; }
        [XmlElement(ElementName = "RelatedFunc")]
        public string RelatedFunc { get; set; }
    }

    [XmlRoot(ElementName = "InputSource")]
    public class InputSource
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "Group")]
    public class Group
    {
        [XmlElement(ElementName = "GroupName")]
        public string GroupName { get; set; }
    }

    [XmlRoot(ElementName = "GroupList")]
    public class GroupList
    {
        [XmlElement(ElementName = "Group")]
        public List<Group> Group { get; set; }
    }

    [XmlRoot(ElementName = "Mode")]
    public class Mode
    {
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "GroupName")]
        public string GroupName { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "SurroundMode")]
    public class SurroundMode
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "GroupList")]
        public GroupList GroupList { get; set; }
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "Cursor")]
    public class Cursor
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "CursorType")]
        public string CursorType { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "QuickSelect1")]
    public class QuickSelect1
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
    }

    [XmlRoot(ElementName = "QuickSelect2")]
    public class QuickSelect2
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
    }

    [XmlRoot(ElementName = "QuickSelect3")]
    public class QuickSelect3
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
    }

    [XmlRoot(ElementName = "QuickSelect4")]
    public class QuickSelect4
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
    }

    [XmlRoot(ElementName = "QuickSelect")]
    public class QuickSelect
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "MaxQuickSelect")]
        public string MaxQuickSelect { get; set; }
        [XmlElement(ElementName = "QuickSelect1")]
        public QuickSelect1 QuickSelect1 { get; set; }
        [XmlElement(ElementName = "QuickSelect2")]
        public QuickSelect2 QuickSelect2 { get; set; }
        [XmlElement(ElementName = "QuickSelect3")]
        public QuickSelect3 QuickSelect3 { get; set; }
        [XmlElement(ElementName = "QuickSelect4")]
        public QuickSelect4 QuickSelect4 { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
    }

    [XmlRoot(ElementName = "Band")]
    public class Band
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "BandList")]
    public class BandList
    {
        [XmlElement(ElementName = "Band")]
        public List<Band> Band { get; set; }
    }

    [XmlRoot(ElementName = "ModeList")]
    public class ModeList
    {
        [XmlElement(ElementName = "Mode")]
        public List<Mode> Mode { get; set; }
    }

    [XmlRoot(ElementName = "TunerOperation")]
    public class TunerOperation
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "TunerType")]
        public string TunerType { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "MaxPresets")]
        public string MaxPresets { get; set; }
        [XmlElement(ElementName = "BandList")]
        public BandList BandList { get; set; }
        [XmlElement(ElementName = "ModeList")]
        public ModeList ModeList { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "BdOperation")]
    public class BdOperation
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "CdOperation")]
    public class CdOperation
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "DockOperation")]
    public class DockOperation
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "DispName")]
        public string DispName { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "PartyZone")]
    public class PartyZone
    {
        [XmlElement(ElementName = "Capability")]
        public string Capability { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "FilteringSource")]
    public class FilteringSource
    {
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
    }

    [XmlRoot(ElementName = "GetFilteredFavoriteList")]
    public class GetFilteredFavoriteList
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SetFilteredFavoritePlay")]
    public class SetFilteredFavoritePlay
    {
        [XmlAttribute(AttributeName = "ver")]
        public string Ver { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "InternetRadio")]
    public class InternetRadio
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "MaxPresets")]
        public string MaxPresets { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "SiriusXM")]
    public class SiriusXM
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "Pandora")]
    public class Pandora
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "SpotifyConnect")]
    public class SpotifyConnect
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "Functions")]
        public string Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "MediaServer")]
    public class MediaServer
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "iPod")]
    public class IPod
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "FuncName")]
        public string FuncName { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "NetUsb")]
    public class NetUsb
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "Favorites")]
        public Favorites Favorites { get; set; }
        [XmlElement(ElementName = "InternetRadio")]
        public InternetRadio InternetRadio { get; set; }
        [XmlElement(ElementName = "SiriusXM")]
        public SiriusXM SiriusXM { get; set; }
        [XmlElement(ElementName = "Pandora")]
        public Pandora Pandora { get; set; }
        [XmlElement(ElementName = "SpotifyConnect")]
        public SpotifyConnect SpotifyConnect { get; set; }
        [XmlElement(ElementName = "MediaServer")]
        public MediaServer MediaServer { get; set; }
        [XmlElement(ElementName = "iPod")]
        public IPod IPod { get; set; }
    }

    [XmlRoot(ElementName = "iPodPlayer")]
    public class IPodPlayer
    {
        [XmlElement(ElementName = "Control")]
        public string Control { get; set; }
        [XmlElement(ElementName = "IconId")]
        public string IconId { get; set; }
        [XmlElement(ElementName = "SourcePath")]
        public string SourcePath { get; set; }
        [XmlElement(ElementName = "ControlMethod")]
        public string ControlMethod { get; set; }
        [XmlElement(ElementName = "Functions")]
        public Functions Functions { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public string ShortcutControl { get; set; }
    }

    [XmlRoot(ElementName = "DeviceZoneCapabilities")]
    public class DeviceZoneCapabilities
    {
        [XmlElement(ElementName = "Zone")]
        public Zone Zone { get; set; }
        [XmlElement(ElementName = "ShortcutControl")]
        public ShortcutControl ShortcutControl { get; set; }
        [XmlElement(ElementName = "Power")]
        public Power Power { get; set; }
        [XmlElement(ElementName = "Volume")]
        public Volume Volume { get; set; }
        [XmlElement(ElementName = "Mute")]
        public Mute Mute { get; set; }
        [XmlElement(ElementName = "InputSource")]
        public InputSource InputSource { get; set; }
        [XmlElement(ElementName = "SurroundMode")]
        public SurroundMode SurroundMode { get; set; }
        [XmlElement(ElementName = "Setup")]
        public Setup Setup { get; set; }
        [XmlElement(ElementName = "Operation")]
        public Operation Operation { get; set; }
        [XmlElement(ElementName = "NetUsb")]
        public NetUsb NetUsb { get; set; }
        [XmlElement(ElementName = "iPodPlayer")]
        public IPodPlayer IPodPlayer { get; set; }
    }

    [XmlRoot(ElementName = "Device_Info")]
    public class Device_Info
    {
        [XmlElement(ElementName = "DeviceInfoVers")]
        public string DeviceInfoVers { get; set; }
        [XmlElement(ElementName = "CommApiVers")]
        public string CommApiVers { get; set; }
        [XmlElement(ElementName = "Gen")]
        public string Gen { get; set; }
        [XmlElement(ElementName = "BrandCode")]
        public string BrandCode { get; set; }
        [XmlElement(ElementName = "ProductCategory")]
        public string ProductCategory { get; set; }
        [XmlElement(ElementName = "CategoryName")]
        public string CategoryName { get; set; }
        [XmlElement(ElementName = "ManualModelName")]
        public string ManualModelName { get; set; }
        [XmlElement(ElementName = "DeliveryCode")]
        public string DeliveryCode { get; set; }
        [XmlElement(ElementName = "ModelName")]
        public string ModelName { get; set; }
        [XmlElement(ElementName = "MacAddress")]
        public string MacAddress { get; set; }
        [XmlElement(ElementName = "UpgradeVersion")]
        public string UpgradeVersion { get; set; }
        [XmlElement(ElementName = "ReloadDeviceInfo")]
        public string ReloadDeviceInfo { get; set; }
        [XmlElement(ElementName = "DeviceZones")]
        public string DeviceZones { get; set; }
        [XmlElement(ElementName = "DeviceCapabilities")]
        public DeviceCapabilities DeviceCapabilities { get; set; }
        [XmlElement(ElementName = "DeviceZoneCapabilities")]
        public List<DeviceZoneCapabilities> DeviceZoneCapabilities { get; set; }
    }

}
