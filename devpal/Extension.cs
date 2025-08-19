using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CommandPalette.Extensions;

namespace Devpal;

[Guid("a8b1f9d6-955d-4602-bef9-d50b2dcf6ef9")]
public sealed partial class Extension : IExtension, IDisposable
{
    private readonly ManualResetEvent extensionDisposedEvent;

    private readonly Provider provider = new();

    public Extension(ManualResetEvent extensionDisposedEvent)
    {
        this.extensionDisposedEvent = extensionDisposedEvent;
    }

    public object? GetProvider(ProviderType providerType)
    {
        return providerType switch
        {
            ProviderType.Commands => provider,
            _ => null,
        };
    }

    public void Dispose() => this.extensionDisposedEvent.Set();
}
