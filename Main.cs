using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Core.Capabilities;
using CounterStrikeSharp.API.Modules.Commands;

public class JailServiceTestPlugin : BasePlugin
{
    public override string ModuleName => "Hello World Plugin";

    public override string ModuleVersion => "0.0.1";

    public override void Load(bool hotReload)
    {
        AddCommand("test_warden","test warden",TestWarden);
    }

    public static PluginCapability<IWardenService> wardenService {get; } = new ("jailbreak:warden_service");

    public static void TestWarden(CCSPlayerController? invoke, CommandInfo command)
    {
        if(invoke == null || !invoke.IsValid)
        {
            return;
        }

        var service = wardenService.Get();

        if(service != null)
        {
            invoke.PrintToChat($"are you a warden?: {service.IsWarden(invoke)}");
        }

        else
        {
            invoke.PrintToChat("no service");
        }
    }
}
