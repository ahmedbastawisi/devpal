// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.IdentityModel.Tokens.Jwt;

namespace devpal;

internal sealed partial class JwtPage : ContentPage
{
    public JwtPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        Title = "devpal:jwt";
        Name = "Open";
    }


    public override IContent[] GetContent()
    {
        var token = "";

        if (string.IsNullOrWhiteSpace(token))
        {
            return [
                new MarkdownContent("### Invalid jwt token"),
            ];
        }

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        return [
            new MarkdownContent($"### Jwt Decoded \n {jwt}"),
        ];
    }
}
