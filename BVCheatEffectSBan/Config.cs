using Rocket.API;

namespace BVCheatEffectSBan
{
    public class Config : IRocketPluginConfiguration
    {
        public ushort DefaultEffect { get; set; } = 167; // Дефолтное значение для ID эффекта
        public uint DefaultBanTime { get; set; } = 8; // Дефолтное значение для времени бана в секундах
        public string BanCommand { get; set; } = "/sban {0} perm Cheating"; // Команда для бана

        public void LoadDefaults()
        {
            DefaultEffect = 167; // Установите ваше дефолтное значение для ID эффекта
            DefaultBanTime = 8; // Установите ваше дефолтное значение для времени бана
            BanCommand = "/sban {0} perm Cheating"; // Установите вашу дефолтную команду для бана
        }
    }
}
