// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Moq;

using Xunit;

namespace Wangkanai.Detection.DependencyInjection
{
    public class DetectionApplicationBuilderExtensionsTest
    {
        [Fact]
        public void UseDetection_ThrowsInvalidOptionException_IfDetectionMarkerServiceIsNotRegistered()
        {
            // Arrange
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(s => s.GetService(typeof(ILoggerFactory)))
                .Returns(Mock.Of<NullLoggerFactory>());
            var applicationBuilderMock = new Mock<IApplicationBuilder>();
            applicationBuilderMock
                .Setup(s => s.ApplicationServices)
                .Returns(serviceProvider.Object);

            // Act
            var exception = Assert.Throws<InvalidOperationException>(
                () => applicationBuilderMock.Object.UseDetection());

            // Assert
            Assert.Equal("AddDetection() is not added to ConfigureServices(...)", exception.Message);
        }
    }
}
