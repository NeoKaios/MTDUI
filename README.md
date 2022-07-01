# MTDUI
A simple UI library for [20 Minutes Till Dawn](https://store.steampowered.com/app/1966900/20_Minutes_Till_Dawn/).

## Installation
If your game isn't modded with BepinEx, DO THAT FIRST! Simply go to the [latest BepinEx release](https://github.com/BepInEx/BepInEx/releases) and extract BepinEx_x64_VERSION.zip directly into your game's folder, then run the game once to install BepinEx properly.

Next, go to the [latest release of this mod](https://github.com/legoandmars/MTDUI/releases/latest) and extract it directly into your game's folder. Make sure it's extracted directly into your game's folder and not into a subfolder!


## For Developers
MTDUI is primarily meant to be used in conjunction with the BepInEx configuration system.

**NOTE:** MTDUI is still in early development, and as such only currently supports a few types of config options:
| ConfigEntry Type  | Supported |
| ------------- | ------------- |
| Enum  | ✅  |
| Int  | ✅  |
| Float  | ✅ |
| Bool  | ✅  |
| String  | ❌  |
| Others?  | ❌  |

Support for new ConfigEntry types will be added as the library matures.

### Example Usage

```cs
using MTDUI;
// Create a new configuration file using the BepInEx config system
var customFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "GameSpeed.cfg"), true);

// Add a config option
var gameSpeed = customFile.Bind("General", "Game Speed", 1, "The speed at which the game runs.");

// Register the config option with MTDUI's in-game mod settings
// 1, 2, 3, 4, 5, and 10 are valid options that can be selected
// This option will only show on the main title screen Mod Options panel
ModOptions.Register(gameSpeed, new List<int>(){ 1, 2, 3, 4, 5, 10 });

// If your config/patch support being change mid-run (using gameSpeed.SettingChanged EventHandler for instance)
// This option will be modifiable in the every Mod Options panel
// "Custom Mod Name" is the section in which the config will be shown, if not specified, the assemblyname is used
ModOptions.Register(gameSpeed, new List<int>(){ 1, 2, 3, 4, 5, 10 }, MTDUI.ConfigEntryLocationType.Everywhere, "Custom Mod Name");

// The acceptableValues list is filled automatically for bool and enum configEntries


// You can add configs to a global section called "Mod List"
// This section is intended to store the general activation configEntry of your mod, as to not clutter up the submenu with inactive mods
// Something like that, in the first lines of your plugin, is the expected usage
activateMod = Config.Bind("Activation", "SpeedMod", true, "If false, the mod does not load");
ModOptions.RegisterOptionInModList(activateMod);
if (!activateMod.Value) return;

// gameSpeed should now be updated when changed in the ingame UI (or when the cfg file is manually modified)
// Use gameSpeed.Value when you want to actually use the value
```

For more information on how the BepInEx config system works, check out [the official documentation](https://docs.bepinex.dev/articles/dev_guide/plugin_tutorial/4_configuration.html).