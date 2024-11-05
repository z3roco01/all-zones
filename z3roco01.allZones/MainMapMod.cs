using GDWeave;
using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace z3roco01.allZones;

public class MainMapMod : IScriptMod{
    public bool ShouldRun(string path) => path == "res://Scenes/Map/main_map.gdc";

    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens) {
        var waiter = new MultiTokenWaiter([
            t => t is IdentifierToken{Name:"child"},
            t => t.Type is TokenType.Period,
            t => t is IdentifierToken{Name:"visible"},
            t => t.Type is TokenType.OpAssign,
        ], allowPartialMatch: false);

        foreach(var token in tokens) {
            yield return token;

            if (waiter.Check(token)) {
                yield return new ConstantToken(new BoolVariant(true));
                yield return new Token(TokenType.Newline, 2);
            }
        }
    }
}
