using System.Runtime.InteropServices;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory.DynamicFunctions;

namespace CnD_Sound;

public static class CustomHooks
{
    public static CustomGameData? CustomFunctions { get; private set; }
    private static bool _isHooked = false;

    internal static void StartHook()
    {
        if (_isHooked) return;
        
        CustomFunctions = new CustomGameData();
        _isHooked = true;
        Helper.DebugMessage("Hooks Started Successfully");
    }

    internal static void UnHook()
    {
        if (!_isHooked || CustomFunctions == null) return;
        
        if (CustomFunctions.CSoundOpGameSystem_SetSoundEventParamFunc_2 != null)
        {
            CustomFunctions.CSoundOpGameSystem_SetSoundEventParamFunc_2.Unhook(CSoundOpGameSystem_StartSoundEventFunc_2_PreHook, HookMode.Pre);
        }

        CustomFunctions = null;
        _isHooked = false;
        Helper.DebugMessage("Hooks Removed Successfully");
    }

    // This hook runs for every sound parameter the server sets, so keep it minimal: the OS (and with it the
    // parameter index) is resolved once instead of on every call.
    private static readonly int HashParamIndex = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 3 : 2;

    public static HookResult CSoundOpGameSystem_StartSoundEventFunc_2_PreHook(DynamicHook hook)
    {
        var hash = hook.GetParam<uint>(HashParamIndex);
        if (hash == 0x2D8464AF)
        {
            hook.SetParam<IntPtr>(HashParamIndex, unchecked((IntPtr)0xBD6054E9L)); // CSSharp 375 (KHook): el param esta declarado como IntPtr, un uint lanza "Hook value is not numeric"
        }

        return HookResult.Continue;
    }
}