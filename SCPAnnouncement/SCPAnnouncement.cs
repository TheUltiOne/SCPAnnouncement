using Exiled.API.Features;
using Exiled.API.Enums;
using Server = Exiled.Events.Handlers.Server;

using System;


namespace SCPAnnouncement
{
    public class SCPAnnouncement : Plugin<Config>
    {
        public override string Name { get; } = "SCPAnnouncement";
        public override string Author { get; } = "TheUltiOne";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 11, 0);

        private static SCPAnnouncement Singleton = new SCPAnnouncement();

        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        private EventHandlers events;

        public static SCPAnnouncement Instance => Singleton;

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public override void OnReloaded()
        {
            UnregisterEvents();
            RegisterEvents();
        }

        public void RegisterEvents()
        {
            events = new EventHandlers();
            Server.RoundStarted += events.OnRoundStarted;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= events.OnRoundStarted;
            events = null;
        }
    }
}
