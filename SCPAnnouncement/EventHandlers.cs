using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace SCPAnnouncement
{
    public class EventHandlers
    {
        public void OnRoundStarted()
        {
            MEC.Timing.CallDelayed(0.5f, MakeAnnouncement);
        }

        public void MakeAnnouncement()
        {
            string text = "";
            string announcement = SCPAnnouncement.Instance.Config.SCPAnnouncementCassie;

            var scps = Player.List.Where(x => x.Side == Side.Scp);

            foreach (Player scp in scps)
            {
                text += $" {SCPAnnouncement.Instance.Config.Pronounciations[scp.Role]}";
            }

            switch (scps.Count())
            {
                case 0:
                    Cassie.DelayedMessage(SCPAnnouncement.Instance.Config.NoSCPs, SCPAnnouncement.Instance.Config.CassieDelay, false, true);
                    return;

                case 1:
                    announcement = SCPAnnouncement.Instance.Config.SCPAnnouncementCassieSingular;
                    break;
            }

            announcement.Replace("%scpcount", scps.Count().ToString());
            announcement.Replace("%scpsubjects", text);

            Cassie.DelayedMessage(announcement, SCPAnnouncement.Instance.Config.CassieDelay, false, true);
        }
    }
}