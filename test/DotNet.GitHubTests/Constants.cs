﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace DotNet.GitHubTests;

internal static  class Constants
{
    internal const string TestProjectXml = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""16.5.0"" />
    <PackageReference Include=""MSTest.TestAdapter"" Version=""2.1.0"" />
    <PackageReference Include=""MSTest.TestFramework"" Version=""2.1.0"" />
    <PackageReference Include=""coverlet.collector"" Version=""1.2.0"" />
    <PackageReference Include=""xunit"" Version=""2.4.1"" />
    <PackageReference Include=""xunit.runner.visualstudio"" Version=""2.4.1"" />
  </ItemGroup>

</Project>";
}
