namespace I8Beef.Denon
{
    public static class CommandStrings
    {
        /// <summary>
        /// Values: standby, on
        /// </summary>
        public static string Standby = "MainZone/index.put.asp?cmd0=PutSystem_OnStandby/{0}&cmd1=aspMainZone_WebUpdateStatus/";

        /// <summary>
        /// Values: on, off
        /// </summary>
        public static string MainZonePower = "MainZone/index.put.asp?cmd0=PutZone_OnOff/{0}&cmd1=aspMainZone_WebUpdateStatus/";

        /// <summary>
        /// Values: %3C, %3E
        /// </summary>
        public static string MainZoneVolumeAdjust = "MainZone/index.put.asp?cmd0=PutMasterVolumeBtn/{0}";

        /// <summary>
        /// Values: {desiredVolume}-80
        /// </summary>
        public static string MainZoneVolumeSet = "MainZone/index.put.asp?cmd0=PutMasterVolumeSet/{0}";

        /// <summary>
        /// Values: on, off
        /// </summary>
        public static string MainZoneVolumeMute = "MainZone/index.put.asp?cmd0=PutVolumeMute/{0}&cmd1=aspMainZone_WebUpdateStatus/";

        /// <summary>
        /// Values: BD, CD, DVD, SAT, MPLAY, GAME, TUNER, M-XPORT, NET/USB, FAVORITES, INTERNET+RADIO, 
        /// MEDIA+SERVER, USB/IPOD, FLICKER, PANDORA, NAPSTER, RHAPSODY
        /// </summary>
        public static string MainZoneInputSelect = "MainZone/index.put.asp?cmd0=PutZone_InputFunction/{0}&cmd1=aspMainZone_WebUpdateStatus/";

        /// <summary>
        /// Values: CurLeft, CurRight, CurUp, CurDown
        /// </summary>
        public static string MoveCursor = "MainZone/index.put.asp?cmd0=PutNetAudioCommand/{0}&cmd1=aspMainZone_WebUpdateStatus/&ZoneName=MAIN+ZONE";

        /// <summary>
        /// Values: RIGHT, LEFT 
        /// </summary>
        public static string SurroundModeSwitch = "MainZone/index.put.asp?cmd0=PutSurroundMode/{0}";

        /// <summary>
        /// Values: DOLBY+DIGITAL, DTS+SURROUND, DIRECT, PURE+DIRECT, STEREO, MCH+STEREO, VIRTUAL, AUTO
        /// </summary>
        public static string SurroundMode = "MainZone/index.put.asp?cmd0=PutSurroundMode/{0}&cmd1=aspMainZone_WebUpdateStatus/";

        /// <summary>
        /// Values: FM, AM
        /// </summary>
        public static string TunerBand = "MainZone/index.put.asp?cmd0=PutTunerBand/{0}&ZoneName=MAIN+ZONE";

        /// <summary>
        /// Values: %3C, %3E
        /// </summary>
        public static string TunerAdjust = "MainZone/index.put.asp?cmd0=PutTunerFrequencyBtn/{0}&cmd1=aspMainZone_WebUpdateStatus/&ZoneName=MAIN+ZONE";

        /// <summary>
        /// Values: AUTO, MANUAL
        /// </summary>
        public static string TunerAuto = "MainZone/index.put.asp?cmd0=PutTunerAuto/{0}&ZoneName=MAIN+ZONE";

        /// <summary>
        /// Values: on, off
        /// </summary>
        public static string SecondZonePower = "MainZone/index.put.asp?cmd0=PutZone_OnOff/{0}&cmd1=aspMainZone_WebUpdateStatus/&ZoneName=ZONE2";

        /// <summary>
        /// Values: %3C, %3E
        /// </summary>
        public static string SecondZoneVolumeAdjust = "MainZone/index.put.asp?cmd0=PutMasterVolumeBtn/{0}&ZoneName=ZONE2";

        /// <summary>
        /// Values: on, off
        /// </summary>
        public static string SecondZoneVolumeMute = "MainZone/index.put.asp?cmd0=PutVolumeMute/{0}&cmd1=aspMainZone_WebUpdateStatus/&ZoneName=ZONE2";

        /// <summary>
        /// Values: BD, CD, DVD, SAT, MPLAY, GAME, TUNER, M-XPORT, NET/USB, FAVORITES, INTERNET+RADIO, 
        /// MEDIA+SERVER, USB/IPOD, FLICKER, PANDORA, NAPSTER, RHAPSODY
        /// </summary>
        public static string SecondZoneInputSelect = "MainZone/index.put.asp?cmd0=PutZone_InputFunction/{0}&cmd1=aspMainZone_WebUpdateStatus/&ZoneName=ZONE2";
    }
}
