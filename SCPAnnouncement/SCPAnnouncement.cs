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
        public override Version Version { get; } = new Version(1, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(2, 11, 0);

        public override PluginPriority Priority { get; } = PluginPriority.Low;
        private EventHandlers events;

        public static SCPAnnouncement Instance;

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            Instance = this;

            events = new EventHandlers();
            Server.RoundStarted += events.OnRoundStarted;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= events.OnRoundStarted;
            events = null;

            Instance = null;
        }
    }
}
