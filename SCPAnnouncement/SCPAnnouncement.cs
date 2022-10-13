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
        public override Version Version { get; } = new Version(2, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 3, 0);

        private EventHandlers events;

        public static SCPAnnouncement Instance;

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            Instance = this;

            events = new EventHandlers();
            Server.RoundStarted += events.OnRoundStarted;

            EventHandlers.Pronounciations = EventHandlers.ParsePronounciations(Instance.Config.Pronounciations); // Should find a way to call this when le configs are reloaded
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= events.OnRoundStarted;
            events = null;

            Instance = null;
        }
    }
}
