using Exiled.API.Features;
using System;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace OneShotHeadshot
{
    public class OneShotHeadshot : Plugin<Config>
    {
        private static readonly OneShotHeadshot singleton = new OneShotHeadshot();
        public static OneShotHeadshot Instance => singleton;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 0);

        private Handlers.PlayerShot playerShot;

        private OneShotHeadshot()
        { }

        public override void OnEnabled()
        {
            SubscribeAll();
        }

        public override void OnDisabled()
        {
            UnsubscribeAll();
        }

        public void SubscribeAll()
        {
            playerShot = new Handlers.PlayerShot();

            PlayerHandler.Shot += playerShot.OnPlayerShot;
        }

        public void UnsubscribeAll()
        {
            PlayerHandler.Shot -= playerShot.OnPlayerShot;

            playerShot = null;
        }
    }
}