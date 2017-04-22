using System.Collections.Generic;

namespace I8Beef.Denon.TelnetClient
{
    /// <summary>
    /// Telnet command class.
    /// </summary>
    public class TelnetCommand
    {
        /// <summary>
        /// Command mappings.
        /// </summary>
        public static readonly IDictionary<string, IList<string>> Commands = new Dictionary<string, IList<string>>
        {
            {
                "CV", new List<string>
            {
                "FL UP", "FL DOWN", "FL **",
                "FR UP", "FR DOWN", "FR **",
                "C UP", "C DOWN", "C **",
                "SW UP", "SW DOWN", "SW **",
                "SW2 UP", "SW2 DOWN", "SW2 **",
                "SL UP", "SL DOWN", "SL **",
                "SR UP", "SR DOWN", "SR **",
                "SBL UP", "SBL DOWN", "SBL **",
                "SBR UP", "SBR DOWN", "SBR **",
                "SB UP", "SB DOWN", "SB **",
                "FHL UP", "FHL DOWN", "FHL **",
                "FHR UP", "FHR DOWN", "FHR **",
                "FWL UP", "FWL DOWN", "FWL **",
                "FWR UP", "FWR DOWN", "FWR **",
                "TFL UP", "TFL DOWN", "TFL **",
                "TFR UP", "TFR DOWN", "TFR **",
                "TML UP", "TML DOWN", "TML **",
                "TMR UP", "TMR DOWN", "TMR **",
                "TRL UP", "TRL DOWN", "TRL **",
                "TRR UP", "TRR DOWN", "TRR **",
                "RHL UP", "RHL DOWN", "RHL **",
                "RHR UP", "RHR DOWN", "RHR **",
                "FDL UP", "FDL DOWN", "FDL **",
                "FDR UP", "FDR DOWN", "FDR **",
                "SDL UP", "SDL DOWN", "SDL **",
                "SDR UP", "SDR DOWN", "SDR **",
                "BDL UP", "BDL DOWN", "BDL **",
                "BDR UP", "BDR DOWN", "BDR **",
                "ZRL", "?"
            }
            },
            { "DC", new List<string> { "AUTO", "PCM", "DTS", "?" } },
            { "DIM", new List<string> { "BRI", "DIM", "DAR", "OFF", "SEL", "?" } },
            { "ECO", new List<string> { "ON", "AUTO", "OFF", "?" } },
            { "HD", new List<string> { "?" } },
            {
                "MN", new List<string>
            {
                "CUP", "CDN", "CLT", "CRT",
                "ENT", "RTN", "OPT", "INF",
                "CHL",
                "MEN ON", "MEN OFF", "MEN?",
                "PRV ON", "PRV OFF", "PRV?",
                "ZST ON", "ZST OFF", "ZST?"
            }
            },
            {
                "MS", new List<string>
            {
                "MOVIE",
                "MUSIC",
                "GAME",
                "DIRECT",
                "PURE DIRECT",
                "STEREO",
                "AUTO",
                "DOLBY DIGITAL",
                "DTS SURROUND",
                "MCH STEREO",
                "WIDE SCREEN",
                "SUPER STADIUM",
                "ROCK ARENA",
                "JAZZ CLUB",
                "CLASSIC CONCERT",
                "MONO MOVIE",
                "MATRIX",
                "VIDEO GAME",
                "VIRTUAL",
                "LEFT",
                "RIGHT",
                "?",
                "QUICK1", "QUICK2", "QUICK3", "QUICK4", "QUICK5",
                "QUICK1 MEMORY", "QUICK2 MEMORY", "QUICK3 MEMORY", "QUCIK4 MEMORY", "QUICK5 MEMORY",
                "QUICK ?"
            }
            },
            { "MU", new List<string> { "ON", "OFF", "?" } },
            { "MV", new List<string> { "UP", "DOWN", "**", "?" } },
            { "NS", new List<string> { string.Empty } },
            { "NSA", new List<string> { string.Empty } },
            { "NSE", new List<string> { string.Empty } },
            {
                "PS", new List<string>
            {
                "TONE CTRL ON", "TONE CTRL OFF", "TONE CTRL ?",
                "BAS UP", "BAS DOWN", "BAS **", "BAS ?",
                "TRE UP", "TRE DOWN", "TRE **", "TRE ?",
                "DIL ON", "DIL OFF", "DIL UP", "DIL DOWN", "DIL **", "DIL ?",
                "SWL ON", "SWL OFF", "SWL UP", "SWL DOWN", "SWL **",
                "SWL2 UP", "SWL2 DOWN", "SWL2 **",
                "SWL ?",
                "CINEMA EQ.ON", "CINEMA EQ.OFF", "CINEMA EQ. ?",
                "MODE:MUSIC", "MODE:CINEMA", "MODE:GAME", "MODE:PRO LOGIC", "MODE: ?",
                "PSLOM ON", "PSLOM OFF", "PSLOM ?",
                "FH:ON", "FH:OFF", "FH: ?",
                "SP:FW", "SP:FH", "SP:SB", "SP:HW", "SP:BH", "SP:BW", "SP:FL", "SP:HF", "SP:FR", "SP: ?",
                "PHG LOW", "PHG MID", "PHG HI", "PHG ?",
                "MULTEQ:AUDYSSEY", "MULTEQ:BYP.LR", "MULTEQ:FLAT", "MULTEQ:MANUAL", "MULTEQ:OFF", "MULTEQ ?",
                "DYNEQ ON", "DYNEQ OFF", "DYNEQ ?",
                "REFLEV 0", "REFLEV 5", "REFLEV 10", "REFLEV 15", "REFREV ?",
                "DYNVOL HEV", "DYNVOL MED", "DYNVOL LIT", "DYNVOL OFF", "DYNVOL ?",
                "LFC ON", "LFC OFF", "LFC ?",
                "CNTAMT UP", "CNTAMT DOWN", "CNTAMT **", "CNTAMT ?",
                "DSX ONHW", "DSX ONH", "DSX ONW", "DSX OFF", "DSX ?",
                "STW UP", "STW DOWN", "STW **", "STW ?",
                "STH UP", "STH DOWN", "STH **", "STH ?",
                "GEQ ON", "GEQ OFF", "GEQ ?",
                "DRC AUTO", "DRC LOW ", "DRC MID", "DRC HI", "DRC OFF", "DRC ?",
                "BSC UP", "BSC DOWN", "BSC **", "BSC ?",
                "DEH OFF", "DEH LOW", "DEH MED", "DEH HIGH", "DEH ?",
                "LFE UP", "LFE DOWN", "LFE **", "LFE ?",
                "LFL 00", "LFL 05", "LFL 10", "LFL 15", "LFL ?",
                "EFF ON", "EFF OFF", "EFF UP", "EFF DOWN", "EFF **", "EFF ?",
                "DEL UP", "DEL DOWN", "DEL ***", "DEL ?",
                "PAN ON", "PAN OFF", "PAN ?",
                "DIM UP", "DIM DOWN", "DIM **", "DIM ?",
                "CEN UP", "CEN DOWN", "CEN **", "CEN ?",
                "CEI UP", "CEI DOWN", "CEI **", "CEI?",
                "CEG UP", "CEG DOWN", "CEG **", "CEG ?",
                "CES ON", "CES OFF", "CES ?",
                "SWR ON", "SWR OFF", "SWR ? ",
                "RSZ S", "RSZ MS", "RSZ M", "RSZ ML", "RSZ L", "RSZ ?",
                "DELAY UP", "DELAY DOWN", "DELAY ***", "DELAY?",
                "RSTR OFF", "RSTR LOW", "RSTR MED", "RSTR HI", "RSTR ?",
                "FRONT SPA", "FRONT SPB", "FRONT A+B", "FRONT?"
            }
            },
            {
                "PV", new List<string>
            {
                "OFF", "STD", "MOV", "VVD", "STM", "CTM", "DAY", "NGT", "?",
                "CN UP", "CN DOWN", "CN ***", "CN ?",
                "BR UP", "BR DOWN", "BR ***", "BR ?",
                "ST UP", "ST DOWN", "ST ***", "ST ?",
                "HUE UP", "HUE DOWN", "HUE **", "HUE ?",
                "DNR OFF", "DNR LOW", "DNR MID", "DNR HI", "DNR ?",
                "ENH UP", "ENH DOWN", "ENH ***", "ENH ?"
            }
            },
            { "PW", new List<string> { "ON", "STANDBY", "?" } },
            { "RM", new List<string> { "STA", "END", "?" } },
            { "SD", new List<string> { "AUTO", "HDMI", "DIGITAL", "ANALOG", "EXT.IN", "7.1IN", "NO", "?" } },
            {
                "SI", new List<string>
            {
                "PHONO", "CD", "TUNER", "DVD", "BD", "TV", "SAT/CBL", "MPLAY", "GAME", "HDRADIO", "NET",
                "PANDORA", "SIRIUSXM", "SPOTIFY", "LASTFM", "FLICKR", "IRADIO",
                "SERVER", "FAVORITES",
                "AUX1", "AUX2", "AUX3", "AUX4", "AUX5", "AUX6", "AUX7",
                "BT", "USB/IPOD", "USB", "IPD", "IRP", "FVP",
                "?"
            }
            },
            { "SLP", new List<string> { "OFF", "***", "?" } },
            { "SR", new List<string> { "PHONO", "IPOD", "SOURCE", "?" } },
            { "STBY", new List<string> { "15M", "30M", "60M", "OFF", "?" } },
            { "SV", new List<string> { "DVD", "BD", "TV", "SAT/CBL", "MPLAY", "GAME", "AUX1", "AUX2", "AUX3", "AUX4", "AUX5", "AUX6", "AUX7", "CD", "SOURCE", "ON", "OFF", "?" } },
            { "SY", new List<string> { "REMOTE LOCK ON", "REMOTE LOCK OFF", "PANEL LOCK ON", "PANEL+V LOCK ON", "PANEL LOCK OFF" } },
            {
                "TF", new List<string>
            {
                "ANUP", "ANDOWN", "AN******", "AN?", "ANNAME?",
                "HDUP", "HDDOWN", "HD******", "HDMC*", "HD******MC*", "HD?"
            }
            },
            {
                "TM", new List<string>
            {
                "ANAM", "ANFM", "AN?", "ANAUTO", "ANMANUAL",
                "HDAM", "HDFM", "HDAUTOHD", "HDAUTO", "HDMANUAL", "HDANAAUTO", "HDANAMANU", "HD?"
            }
            },
            {
                "TP", new List<string>
            {
                "ANUP", "ANDOWN", "AN**", "AN?", "ANMEM", "ANMEM**",
                "HDUP", "HDDOWN", "HD**", "HD?", "HDMEM", "HDMEM**"
            }
            },
            { "TR", new List<string> { "1 ON", "1 OFF", "2 ON", "2 OFF", "?" } },
            { "UG", new List<string> { "IDN" } },
            {
                "VS", new List<string>
            {
                "ASPNRM", "ASPFUL", "ASP ?",
                "MONIAUTO", "MONI1", "MONI2", "MONI ?",
                "SC48P", "SC10I", "SC72P", "SC10P", "SC10P24", "SC4K", "SC4KF", "SCAUTO", "SC ?",
                "SCH48P", "SCH10I", "SCH72P", "SCH10P", "SCH10P24", "SCH4K", "SCH4KF", "SCHAUTO", "SCH ?",
                "AUDIO AMP", "AUDIO TV", "AUDIO ?",
                "VPMAUTO", "VPMGAME", "VPMMOVI", "VPM ?"
            }
            },
            {
                "Z2", new List<string>
            {
                "SOURCE", "PHONO", "CD", "TUNER", "DVD", "BD", "TV", "SAT/CBL", "MPLAY", "GAME", "HDRADIO", "NET",
                "PANDORA", "SIRIUSXM", "SPOTIFY", "LASTFM", "FLICKR", "IRADIO",
                "SERVER", "FAVORITES",
                "AUX1", "AUX2", "AUX3", "AUX4", "AUX5", "AUX6", "AUX7",
                "BT", "USB/IPOD", "USB", "IPD", "IRP", "FVP",
                "QUICK1", "QUICK2", "QUICK3", "QUICK4", "QUICK5",
                "QUICK1 MEMORY", "QUICK2 MEMORY", "QUICK3 MEMORY", "QUCIK4 MEMORY", "QUICK5 MEMORY",
                "QUICK ?",
                "FAVORITE1", "FAVORITE2", "FAVORITE3", "FAVORITE4",
                "FAVORITE1 MEMORY　", "FAVORITE2 MEMORY　", "FAVORITE3 MEMORY　", "FAVORITE4 MEMORY　",
                "UP", "DOWN", "**",
                "ON", "OFF", "?"
            }
            },
            { "Z2CS", new List<string> { "ST", "MONO", "?" } },
            { "Z2CV", new List<string> { "FL UP", "FL DOWN", "FL **", "FR UP", "FR DOWN", "FR **", "?" } },
            { "Z2HDA", new List<string> { "THR", "PCM", "?" } },
            { "Z2HPF", new List<string> { "ON", "OFF", "?" } },
            { "Z2MU", new List<string> { "ON", "OFF", "?" } },
            {
                "Z2PS", new List<string>
            {
                "BAS UP", "BAS DOWN", "BAS **", "BAS ?",
                "TRE UP", "TRE DOWN", "TRE **", "TRE ?"
            }
            },
            { "Z2SLP", new List<string> { "OFF", "***", "?" } },
            { "Z2STBY", new List<string> { "2H", "4H", "8H", "OFF", "?" } },
            {
                "Z3", new List<string>
            {
                "SOURCE", "PHONO", "CD", "TUNER", "DVD", "BD", "TV", "SAT/CBL", "MPLAY", "GAME", "HDRADIO", "NET",
                "PANDORA", "SIRIUSXM", "SPOTIFY", "LASTFM", "FLICKR", "IRADIO",
                "SERVER", "FAVORITES",
                "AUX1", "AUX2", "AUX3", "AUX4", "AUX5", "AUX6", "AUX7",
                "BT", "USB/IPOD", "USB", "IPD", "IRP", "FVP",
                "QUICK1", "QUICK2", "QUICK3", "QUICK4", "QUICK5",
                "QUICK1 MEMORY", "QUICK2 MEMORY", "QUICK3 MEMORY", "QUCIK4 MEMORY", "QUICK5 MEMORY",
                "QUICK ?",
                "FAVORITE1", "FAVORITE2", "FAVORITE3", "FAVORITE4",
                "FAVORITE1 MEMORY　", "FAVORITE2 MEMORY　", "FAVORITE3 MEMORY　", "FAVORITE4 MEMORY　",
                "UP", "DOWN", "**",
                "ON", "OFF", "?"
            }
            },
            { "Z3CS", new List<string> { "ST", "MONO", "?" } },
            { "Z3CV", new List<string> { "FL UP", "FL DOWN", "FL **", "FR UP", "FR DOWN", "FR **", "?" } },
            { "Z3HPF", new List<string> { "ON", "OFF", "?" } },
            { "Z3MU", new List<string> { "ON", "OFF", "?" } },
            {
                "Z3PS", new List<string>
            {
                "BAS UP", "BAS DOWN", "BAS **", "BAS ?",
                "TRE UP", "TRE DOWN", "TRE **", "TRE ?"
            }
            },
            { "Z3SLP", new List<string> { "OFF", "***", "?" } },
            { "Z3STBY", new List<string> { "2H", "4H", "8H", "OFF", "?" } },
            { "ZM", new List<string> { "ON", "OFF", "?", "FAVORITE1", "FAVORITE2", "FAVORITE3", "FAVORITE4", "FAVORITE1 MEMORY", "FAVORITE2 MEMORY", "FAVORITE3 MEMORY", "FAVORITE4 MEMORY" } }
        };
    }
}
