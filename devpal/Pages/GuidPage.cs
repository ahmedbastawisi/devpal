// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Devpal;

internal sealed partial class GuidPage : DynamicListPage
{
    private List<IListItem> items = [];

    public GuidPage()
    {
        Name = "guid";
        Title = "devpal: create new guid";
        PlaceholderText = "Type the number guids you want generated";
        Icon = new IconInfo("\uea86");

        BuildItems(1);
    }

    public override IListItem[] GetItems()
    {
        return [.. items];
    }

    public override void UpdateSearchText(string oldSearch, string newSearch)
    {
        _ = int.TryParse(newSearch, out int count);

        BuildItems(Math.Max(Math.Abs(count), 1));

        RaiseItemsChanged();
    }

    private void BuildItems(int count)
    {
        items.Clear();

        var requests = Enumerable.Range(1, count);

        foreach (var _ in requests)
        {
            items.Add(new ListItem { Title = Guid.NewGuid().ToString() });
        }
    }
}