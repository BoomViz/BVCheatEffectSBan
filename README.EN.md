# BVCheatEffectSBan plugin for RocketMod
## EN
### THE PLUGIN IS TRANSLATED INTO RUSSIAN BY DEFAULT! (translation.xml allows you to change this)
- This plugin allows server admins to apply a visual effect to a player and then ban him. In this case, you can set a delay before the ban.
- Apply a visual effect to the cheater before banning him.
- Set a delay before the ban.
- Customizable effect and default ban time.
- Command: /cban <steamID64|Player name> [effectID] [delay in seconds]

### You can edit the following settings:
 - DefaultEffect: ID of the effect that will be applied to players by default. (167)
 - DefaultBanTime: Delay in seconds before the default ban. (8)
 - BanCommand: Command to ban players. (Default /sban SID64 perm cheats)

### To use the plugin, simply enter the following command in chat:

    /cban <steamID64|Player name> [effect id] [delay in seconds]

#### Example:

    /cban 76561198000000000 167 8

- This command will apply the effect with id 167 to the player with SteamID64 76561198000000000, and then ban him after 8 seconds.
- If you do not specify an effect id and delay, the default values ​​from the configuration file will be used.
- If you specify an effect id, but do not specify a delay, the delay will be 0.

 ### Support
- If you have any questions or problems with the plugin, please create an issue in the repository.
