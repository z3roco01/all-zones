using GDWeave;
using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace z3roco01.tutorialTime;

public class MainMapMod : IScriptMod{
    public bool ShouldRun(string path) => path == "res://Scenes/Map/main_map.gdc";

    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens) {
        var waiter = new MultiTokenWaiter([
            t => t is IdentifierToken{Name:"child"},
            t => t.Type is TokenType.Period,
            t => t is IdentifierToken{Name:"visible"},
            t => t.Type is TokenType.OpAssign,
            t => t is IdentifierToken{Name:"child"},
            t => t.Type is TokenType.Period,
            t => t is IdentifierToken{Name:"name"},
            t => t.Type is TokenType.OpEqual,
            t => t is IdentifierToken{Name:"id"},
            t => t.Type is TokenType.Newline,
        ], allowPartialMatch: false);

        foreach(var token in tokens) {
            yield return token;

            if (waiter.Check(token)) {
                // $zones.get_node("tutorial_zone").visible = true
                yield return new Token(TokenType.Dollar);
                yield return new IdentifierToken("zones");
                yield return new Token(TokenType.Period);
                yield return new IdentifierToken("get_node");
                yield return new Token(TokenType.ParenthesisOpen);
                yield return new ConstantToken(new StringVariant("tutorial_zone"));
                yield return new Token(TokenType.ParenthesisClose);
                yield return new Token(TokenType.Period);
                yield return new IdentifierToken("visible");
                yield return new Token(TokenType.OpAssign);
                yield return new ConstantToken(new BoolVariant(true));
            }
        }
    }
}
