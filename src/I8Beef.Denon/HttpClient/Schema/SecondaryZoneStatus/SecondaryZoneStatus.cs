using System.Xml.Serialization;

namespace I8Beef.Denon.HttpClient.Schema.SecondaryZoneStatus
{
    [XmlRoot(ElementName = "Power")]
    public class Power
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
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

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "Power")]
        public Power Power { get; set; }
        [XmlElement(ElementName = "InputFuncSelect")]
        public InputFuncSelect InputFuncSelect { get; set; }
        [XmlElement(ElementName = "VolumeDisplay")]
        public VolumeDisplay VolumeDisplay { get; set; }
        [XmlElement(ElementName = "MasterVolume")]
        public MasterVolume MasterVolume { get; set; }
        [XmlElement(ElementName = "Mute")]
        public Mute Mute { get; set; }
    }

}
