using Rocket.API;

namespace BVCheatEffectSBan
{
    public class Config : IRocketPluginConfiguration
    {
        public string BanCommand { get; set; } = "/sban {0} perm Cheating";

        public void LoadDefaults()
        {
            BanCommand = "/sban {0} perm Cheating";
        }
    }
}