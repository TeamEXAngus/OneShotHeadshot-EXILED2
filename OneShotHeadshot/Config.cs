using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace OneShotHeadshot
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not Zombies should be instakilled by headshots.")]
        public bool InstaKillZombies { get; set; } = true;

        [Description("A list of weapons that instakill when they headshot a player. Leave this empty for all weapons.")]
        public List<ItemType> OneShotHeadShotWeapons = new List<ItemType> { };
    }
}