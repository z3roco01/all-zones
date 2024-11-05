using GDWeave;

namespace z3roco01.allZones;

public class Mod : IMod {
    public static IModInterface ModInterface;

    public Mod(IModInterface modInterface) {
        ModInterface = modInterface;
        modInterface.RegisterScriptMod(new MainMapMod());
        modInterface.Logger.Information("now you have all the zones !");
    }

    public void Dispose() {
    }
}
