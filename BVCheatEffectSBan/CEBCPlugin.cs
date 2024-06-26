﻿using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace BVCheatEffectSBan
{
    public class CEBPlugin : RocketPlugin<Config>
    {
        public static CEBPlugin Instance;
        public static Config Config;

        protected override void Load()
        {
            base.Load();
            Instance = this;
            Config = Configuration.Instance;
            var myMonoBehaviour = new GameObject("MyMonoBehaviour").AddComponent<MyMonoBehaviourClass>();
            DontDestroyOnLoad(myMonoBehaviour);
            Logger.Log("BVCheatEffectSBan plugin loaded successfully.");
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "InvalidSyntax", "Неверный синтаксис. Используйте: /cban <steamID64|playerName> [effectID] [delay]" },
            { "PlayerNotFound", "Игрок не найден." },
            { "ApplyingEffectBan", "Применён эффект {2} и бан к игроку {0} ({1})." },
            { "BanDelay", "Задержка бана: {0} секунд." },
            { "help_cheatban", "Применяет указанный эффект и затем выполняет бан. Если эффект или время не указаны, используются значения по умолчанию." },
            { "syntax_cheatban", "/cban <steamID64|ИмяИгрока> [IDЭффекта] [ВремяЗадержкиВСекундах]" },
        };

        protected override void Unload()
        {
            base.Unload();
            Logger.Log("BVCheatEffectSBan plugin unloaded successfully.");
            Instance = null;
        }
    }
}