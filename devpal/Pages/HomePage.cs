// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Devpal;

internal sealed partial class HomePage : ListPage
{
    public HomePage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.scale-100.png");
        Title = "devpal";
    }

    public override IListItem[] GetItems()
    {
        return [
            new ListItem(new JwtPage()) { Title = "jwt", Subtitle = "decode jwt" },
            new ListItem(new GuidPage()) { Title = "guid", Subtitle = "create new guid" }
        ];
    }
}
