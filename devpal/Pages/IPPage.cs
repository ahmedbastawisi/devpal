using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Diagnostics;

namespace Devpal;

internal sealed partial class IPPage : ListPage
{
    public IPPage()
    {
        Name = "ip";
        Title = "devpal: find your ip";
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
            new ListItem(new ListItem()) { Title = ip }
        ];
    }
}