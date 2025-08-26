using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Devpal;

internal sealed partial class GuidPage : DynamicListPage
{
    private List<IListItem> items = [];

    public GuidPage()
    {
        Name = "guid";
        Title = "devpal: create new guid";
        PlaceholderText = "Type the number guids followed by format ex: 3p, 5x";
        Icon = new IconInfo("\uea86");

        BuildItems(1, "d");
    }

    public override IListItem[] GetItems()
    {
        return [.. items];
    }

    public override void UpdateSearchText(string oldSearch, string newSearch)
    {
        var count = 1;
        var format = "D";
        var match = Regex.Match(newSearch.Trim(), @"^(?<count>\d+)(?<format>[NnDdBbPpXx])?$");

        if (match.Success)
        {
            _ = int.TryParse(match.Groups["count"].Value, out count);

            if (match.Groups["format"].Success)
            {
                format = match.Groups["format"].Value;
            }
        }
        BuildItems(count, format);

        RaiseItemsChanged();
    }

    private void BuildItems(int count, string format)
    {
        items.Clear();

        for (int i = 0; i < count; i++)
        {
            items.Add(new ListItem { Title = Guid.NewGuid().ToString(format) });
        }
    }
}