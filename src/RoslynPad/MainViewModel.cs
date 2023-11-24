﻿using System;
using System.Composition;
using System.Reflection;
using RoslynPad.UI;
using System.Collections.Immutable;

namespace RoslynPad;

[Export(typeof(MainViewModelBase)), Shared]
[method: ImportingConstructor]
public class MainViewModel(IServiceProvider serviceProvider, ITelemetryProvider telemetryProvider, ICommandProvider commands, IApplicationSettings settings, NuGetViewModel nugetViewModel, DocumentFileWatcher documentFileWatcher) : MainViewModelBase(serviceProvider, telemetryProvider, commands, settings, nugetViewModel, documentFileWatcher)
{
    protected override ImmutableArray<Assembly> CompositionAssemblies => base.CompositionAssemblies
        .Add(Assembly.Load(new AssemblyName("RoslynPad.Roslyn.Windows")))
        .Add(Assembly.Load(new AssemblyName("RoslynPad.Editor.Windows")));
}