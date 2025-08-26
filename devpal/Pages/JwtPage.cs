using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Devpal;

internal sealed partial class JwtPage : DynamicListPage
{
    private List<IListItem> items = [];

    public JwtPage()
    {
        Name = "jwt";
        Title = "devpal: decode jwt";
        PlaceholderText = "Pate your bearer token here";
        Icon = new IconInfo("\uea86");
    }

    public override IListItem[] GetItems()
    {
        return [.. items];
    }

    public override void UpdateSearchText(string oldSearch, string newSearch)
    {
        BuildItems("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIxMjM0IiwidXNlcm5hbWUiOiJBbWFuIiwiaWF0IjoxNjkzNTM4NDAwLCJleHAiOjE2OTM1NDIwMDB9.gKfj8A0c9z0U2a4N2QF-7I4Nf7h8v6Y2Uq7aT1h6lG4");

        RaiseItemsChanged();
    }

    private void BuildItems(string token)
    {
        items.Clear();

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        foreach (var claim in jwt.Claims)
        {
            items.Add(new ListItem { Title = claim.Type, Subtitle = claim.Value });
        }
    }
}