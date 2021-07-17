using System.ComponentModel;
using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace SCPAnnouncement
{
    public sealed class Config : IConfig
    {
        [Description("Sets if SCP Announcement is enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("Sets the Cassie announcement where no SCPs have breached")]
        public string NoSCPs { get; set; } = "0 SCPSUBJECTS HAVE BREACHED";

        [Description("Sets the Cassie announcement [%scpcount and %scpsubjects]")]
        public string SCPAnnouncementCassie { get; set; } = "ATTENTION ALL PERSONNEL DETECTED %scpcount SCPSUBJECTS %scpsubjects";

        [Description("Sets the Cassie announcement when there is only 1 SCP")]
        public string SCPAnnouncementCassieSingular { get; set; } = "ATTENTION ALL PERSONNEL DETECTED %scpcount SCPSUBJECT %scpsubjects";

        [Description("Sets the delay until the announcement (this should generally be over 1s)")]
        public ushort CassieDelay { get; set; } = 3;

        [Description("Sets how cassie pronounces each SCP")]
        public Dictionary<RoleType, string> Pronounciations { get; set; } = new Dictionary<RoleType, string>
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
    }
}