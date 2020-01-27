// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using Wangkanai.Detection.Models;

namespace Wangkanai.Detection.Services
{
    public interface IPlatformService
    {
        Processor       Processor       { get; }
        OperatingSystem OperatingSystem { get; }
    }
}