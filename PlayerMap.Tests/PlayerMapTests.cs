using System;
using Xunit;

namespace PlayerMap.Tests
{
    public class PlayerMapTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public void Player_CanSetToken()
        {
            var expected_Token = "#";
            var player = new Player(expected_Token);
            Assert.True(player.player_token == expected_Token);
            Assert.NotEmpty(player.player_token);

        }
    }
}
