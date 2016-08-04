using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace I8Beef.Denon.Schema
{
    [Serializable]
    [XmlRoot("item")]
    public class Item
    {
        /*         
            <?xml version="1.0" encoding="utf-8" ?>
            <item>
            <FriendlyName><value>Denon AVR-X2200W</value></FriendlyName>
            <Power><value>ON</value></Power>
            <ZonePower><value>ON</value></ZonePower>
            <RenameZone><value>MAIN ZONE             </value></RenameZone>
            <TopMenuLink><value>ON</value></TopMenuLink>
            <VideoSelectDisp><value>OFF</value></VideoSelectDisp>
            <VideoSelect><value></value></VideoSelect>
            <VideoSelectOnOff><value>OFF</value></VideoSelectOnOff>
            <VideoSelectLists>
            <value index='ON' >On</value>
            <value index='OFF' >Off</value>
            </VideoSelectLists>
            <ECOModeDisp><value>ON</value></ECOModeDisp>
            <ECOMode><value></value></ECOMode>
            <ECOModeLists>
            <value index='ON'  table='ECO : ON' param=''/>
            <value index='OFF'  table='ECO : OFF' param=''/>
            <value index='AUTO'  table='ECO : AUTO' param=''/>
            </ECOModeLists>
            <AddSourceDisplay><value>FALSE</value></AddSourceDisplay>
            <ModelId><value>2</value></ModelId>
            <BrandId><value>DENON_MODEL</value></BrandId>
            <SalesArea><value>0</value></SalesArea>
            <InputFuncSelect><value>CBL/SAT</value></InputFuncSelect>
            <NetFuncSelect><value>FAVORITES</value></NetFuncSelect>
            <selectSurround><value>Dolby D + Dolby Surround       </value></selectSurround>
            <VolumeDisplay><value>Absolute</value></VolumeDisplay>
            <MasterVolume><value>-40.0</value></MasterVolume>
            <Mute><value>off</value></Mute>
            <RemoteMaintenance><value></value></RemoteMaintenance>
            <SubwooferDisplay><value>FALSE</value></SubwooferDisplay>
            <Zone2VolDisp><value>TRUE</value></Zone2VolDisp>
            <SleepOff><value>Off</value></SleepOff>
            </item>
            */
        [XmlElement("FriendlyName")]
        public string FriendlyName { get; set; }

        public string Power { get; set; }
        public string ZonePower { get; set; }

        public string RenameZone { get; set; }
        public string TopMenuLink { get; set; }
        public string VideoSelectDisp { get; set; }
        public string VideoSelect { get; set; }
        public string VideoSelectOnOff { get; set; }
        public List<string> VideoSelectLists { get; set; }
        public string ECOModeDisp { get; set; }
        public string ECOMode { get; set; }
        public List<string> ECOModeLists { get; set; }
        public string AddSourceDisplay { get; set; }
        public string ModelId { get; set; }
        public string BrandId { get; set; }
        public string SalesArea { get; set; }
        public string InputFuncSelect { get; set; }

        public string NetFuncSelect { get; set; }
        public string selectSurround { get; set; }
        public string VolumeDisplay { get; set; }
        public string MasterVolume { get; set; }
        public string Mute { get; set; }

        public string RemoteMaintenance { get; set; }
        public string SubwooferDisplay { get; set; }
        public string Zone2VolDisp { get; set; }
        public string SleepOff { get; set; }
    }
}
