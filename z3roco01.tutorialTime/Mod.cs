using GDWeave;

namespace z3roco01.tutorialTime;

public class Mod : IMod {
    public static IModInterface ModInterface;

    public Mod(IModInterface modInterface) {
        ModInterface = modInterface;
        modInterface.RegisterScriptMod(new MainMapMod());
        modInterface.Logger.Information("tutorial time !");
    }

    public void Dispose() {
    }
}
