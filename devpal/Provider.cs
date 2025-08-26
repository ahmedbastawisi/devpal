using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Devpal;

public partial class Provider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public Provider()
    {
        DisplayName = "devpal";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        _commands = [
            new CommandItem(new HomePage()) { Title = DisplayName, Subtitle = "Various dev tools" },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}
