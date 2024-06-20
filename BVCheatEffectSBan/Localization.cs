using BVCheatEffectSBan;

namespace BVCheatEffectSBan.Translation
{
    public static class Translation
    {
        public static string Translate(this string Translation, params object[] Args)
        {
            if (CEBPlugin.Instance.Translations.Instance[Translation] != null)
            {
                return CEBPlugin.Instance.Translate(Translation, placeholder: Args);
            }
            else
            {
                return CEBPlugin.Instance.DefaultTranslations.Translate(Translation, placeholder: Args);
            }
        }
    }
}