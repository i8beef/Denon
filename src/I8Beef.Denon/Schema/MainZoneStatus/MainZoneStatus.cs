using System.Xml.Serialization;
using System.Collections.Generic;

namespace I8Beef.Denon.Schema.MainZoneStatus
{
    [XmlRoot(ElementName = "Zone")]
    public class Zone
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Power")]
    public class Power
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "InputFuncList")]
    public class InputFuncList
    {
        [XmlElement(ElementName = "value")]
        public List<string> Value { get; set; }
    }

    [XmlRoot(ElementName = "value")]
    public class MainStatusValue
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "RenameSource")]
    public class RenameSource
    {
        [XmlElement(ElementName = "value")]
        public List<MainStatusValue> Value { get; set; }
    }

    [XmlRoot(ElementName = "SourceDelete")]
    public class SourceDelete
    {
        [XmlElement(ElementName = "value")]
        public List<string> Value { get; set; }
    }

    [XmlRoot(ElementName = "InputFuncSelect")]
    public class InputFuncSelect
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "VolumeDisplay")]
    public class VolumeDisplay
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "RestorerMode")]
    public class RestorerMode
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "SurrMode")]
    public class SurrMode
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "MasterVolume")]
    public class MasterVolume
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Mute")]
    public class Mute
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Model")]
    public class Model
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "Zone")]
        public Zone Zone { get; set; }
        [XmlElement(ElementName = "Power")]
        public Power Power { get; set; }
        [XmlElement(ElementName = "InputFuncList")]
        public InputFuncList InputFuncList { get; set; }
        [XmlElement(ElementName = "RenameSource")]
        public RenameSource RenameSource { get; set; }
        [XmlElement(ElementName = "SourceDelete")]
        public SourceDelete SourceDelete { get; set; }
        [XmlElement(ElementName = "InputFuncSelect")]
        public InputFuncSelect InputFuncSelect { get; set; }
        [XmlElement(ElementName = "VolumeDisplay")]
        public VolumeDisplay VolumeDisplay { get; set; }
        [XmlElement(ElementName = "RestorerMode")]
        public RestorerMode RestorerMode { get; set; }
        [XmlElement(ElementName = "SurrMode")]
        public SurrMode SurrMode { get; set; }
        [XmlElement(ElementName = "MasterVolume")]
        public MasterVolume MasterVolume { get; set; }
        [XmlElement(ElementName = "Mute")]
        public Mute Mute { get; set; }
        [XmlElement(ElementName = "Model")]
        public Model Model { get; set; }
    }

}
