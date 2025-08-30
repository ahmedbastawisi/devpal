using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Diagnostics;
using Windows.System;

namespace Devpal;

internal sealed partial class IPPage : ListPage
{
    public IPPage()
    {
        Name = "ip";
        Title = "devpal: find your public ip";
        Icon = new IconInfo("\uea86");
    }

    public override IListItem[] GetItems()
    {
        var ip = string.Empty;
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "curl",
                Arguments = "-s ip.me",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(psi);
            process!.WaitForExit(3000); // wait up to 3 seconds

            ip = process.StandardOutput.ReadToEnd().Trim();
        }
        catch
        {

        }

        return [
            new ListItem(new ListItem())
            {
                Title = ip,
                MoreCommands = [
                    new CommandContextItem(new AnonymousCommand(() => ClipboardHelper.SetText(ip))
                    {
                        Name = "Copy"
                    })
                    { 
                        RequestedShortcut = KeyChordHelpers.FromModifiers(ctrl: false, shift: false, vkey: VirtualKey.Enter)
                    }
                ]
            }
        ];
    }
}