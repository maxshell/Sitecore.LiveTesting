﻿namespace Sitecore.LiveTesting.Extensions.Tests.Request
{
  using System.Linq;
  using Sitecore.LiveTesting.Extensions.InitializationHandlers.Request;
  using Sitecore.LiveTesting.Extensions.Request;
  using Sitecore.Security.Accounts;
  using Xunit;

  /// <summary>
  /// Defines the test class for <see cref="AuthenticatedRequest"/>.
  /// </summary>
  public class AuthenticatedRequestTest
  {
    /// <summary>
    /// Should set initialization handlers on construction.
    /// </summary>
    [Fact]
    public void ShouldSetInitializationHandlersOnConstruction()
    {
      const string UserName = "user name";
      
      AuthenticatedRequest request = new AuthenticatedRequest(UserName);

      Assert.Equal(2, request.InitializationHandlers.Count);
      Assert.Equal(typeof(HttpContextProvider), request.InitializationHandlers.First().Key);
      Assert.Empty(request.InitializationHandlers.First().Value);
      Assert.Equal(typeof(UserSwitcher), request.InitializationHandlers.ElementAt(1).Key);
      Assert.Equal(2, request.InitializationHandlers.ElementAt(1).Value.Length);
      Assert.Equal(UserName, request.InitializationHandlers.ElementAt(1).Value[0]);
      Assert.Equal(true, request.InitializationHandlers.ElementAt(1).Value[1]);
    }
  }
}