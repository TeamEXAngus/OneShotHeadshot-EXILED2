using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace OneShotHeadshot.Handlers
{
    internal class PlayerShot
    {
        private Config Configs => OneShotHeadshot.Instance.Config;

        // Despite what the docs say, Handlers.Player.Shot only gets called
        // when a player is the target.
        public void OnPlayerShot(ShotEventArgs ev)
        {
            Player Target = Player.Get(ev.Target);

            if (IsHeadshot(ev.HitboxTypeEnum) && CanBeInstaKilled(Target) && UsingAllowedWeapon(ev.Shooter))
            {
                ev.Damage = Target.Health;
            }
        }

        private bool IsHeadshot(HitBoxType HitPosition) => HitPosition == HitBoxType.HEAD;

        private bool CanBeInstaKilled(Player Target) => Target.Role != RoleType.Scp0492 || Configs.InstaKillZombies;

        private bool UsingAllowedWeapon(Player Shooter) => Configs.OneShotHeadShotWeapons.Count == 0 ||
            Configs.OneShotHeadShotWeapons.Contains(Shooter.CurrentItem.id);
    }
}