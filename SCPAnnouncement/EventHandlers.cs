using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace SCPAnnouncement
{
    public class EventHandlers
    {
        public static Dictionary<RoleType, string> Pronounciations = new Dictionary<RoleType, string>();

        public static List<RoleType> SCPs = new List<RoleType>()
        {
            RoleType.Scp049,
            RoleType.Scp0492,
            RoleType.Scp079,
            RoleType.Scp096,
            RoleType.Scp106,
            RoleType.Scp173,
            RoleType.Scp93953,
            RoleType.Scp93989
        };

        public static Dictionary<RoleType, string> DefaultPronounciations = new Dictionary<RoleType, string>()
        {
            { RoleType.Scp049, "SCP 0 4 9"},
            { RoleType.Scp0492, "SCP 0 4 9 2" },
            { RoleType.Scp079, "SCP 0 7 9" },
            { RoleType.Scp096, "SCP 0 9 6" },
            { RoleType.Scp106, "SCP 1 0 6" },
            { RoleType.Scp173, "SCP 1 7 3" },
            { RoleType.Scp93953, "SCP 9 3 9 5 3" },
            { RoleType.Scp93989, "SCP 9 3 9 8 9" }
        };

        public static Dictionary<RoleType, string> ParsePronounciations(Dictionary<RoleType, string> ToParse)
        {
            var Parsed = new Dictionary<RoleType, string>();
            foreach (RoleType SCP in SCPs)
            {
                if (!ToParse.ContainsKey(SCP))
                {
                    Parsed.Add(SCP, DefaultPronounciations[SCP]);
                    Log.Warn($"SCPAnnouncement is missing pronounciation {SCP}; added as the default pronounciation: '{DefaultPronounciations[SCP]}'.");

                    continue;
                }

                Parsed.Add(SCP, SCPAnnouncement.Instance.Config.Pronounciations[SCP]);
            }

            return Parsed;
        }

        public void OnRoundStarted()
        {
            MEC.Timing.CallDelayed(SCPAnnouncement.Instance.Config.CassieDelay, MakeAnnouncement);
        }

        public void MakeAnnouncement()
        {
            string text = "";
            string announcement = SCPAnnouncement.Instance.Config.SCPAnnouncementCassie;

            var scps = Player.Get(Side.Scp);

            switch (scps.Count())
            {
                case 0:
                    Cassie.Message(SCPAnnouncement.Instance.Config.NoSCPs, false, true);
                    return;

                case 1:
                    announcement = SCPAnnouncement.Instance.Config.SCPAnnouncementCassieSingular;
                    break;
            }

            foreach (Player scp in scps)
            {
                text += $" {Pronounciations[scp.Role]}";
            }

            announcement = announcement.Replace("%scpcount", scps.Count().ToString());
            announcement = announcement.Replace("%scpsubjects", text);

            Cassie.Message(announcement, false, true);
        }
    }
}