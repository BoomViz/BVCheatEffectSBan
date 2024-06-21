using SDG.Unturned;
using UnityEngine;

public static class PlayerSpeedManager
{
    // Уменьшение скорости игрока
    public static void ReducePlayerSpeed(Player player)
    {
        if (player != null && player.life != null)
        {
            PlayerMovement movement = player.movement;
            if (movement != null)
            {
                movement.sendPluginSpeedMultiplier(0.3f);
            }
        }
    }

    // Восстановление скорости игрока
    public static void RestorePlayerSpeed(Player player)
    {
        if (player != null && player.life != null)
        {
            PlayerMovement movement = player.movement;
            if (movement != null)
            {
                movement.sendPluginSpeedMultiplier(1.0f);
            }
        }
    }
}