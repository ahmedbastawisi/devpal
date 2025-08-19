using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Devpal;

internal sealed partial class JwtPage : ListPage
{
    public JwtPage()
    {
        Name = "jwt";
        Title = "devpal: decode bearer token";
        PlaceholderText = "Copy a bearer token to clipboard";
        Icon = new IconInfo("\uea86");
    }

    public override IListItem[] GetItems()
    {
        var items = new List<IListItem>();

        var handler = new JwtSecurityTokenHandler();

        if (!handler.CanReadToken(ClipboardHelper.GetText()))
        {
            items.Add(new ListItem
            {
                Title = "Clipboard does not contain a valid JWT token",
                Subtitle = "Make sure you copied the entire token"
            });
            return [.. items];
        }

        var jwt = handler.ReadJwtToken(ClipboardHelper.GetText());

        foreach (var header in jwt.Header)
        {
            items.Add(new ListItem { Title = header.Key, Subtitle = header.Value.ToString()! });
        }

        foreach (var claim in jwt.Claims)
        {
            items.Add(new ListItem { Title = claim.Type, Subtitle = claim.Value });
        }
        return [.. items];
    }
}