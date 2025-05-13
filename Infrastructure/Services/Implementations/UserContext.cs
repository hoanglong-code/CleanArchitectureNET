using Infrastructure.Commons;
using Infrastructure.Services.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Implementations
{
    public class UserContext : IUserContext
    {
        private UserClaims _userClaims;
        public UserClaims userClaims => _userClaims;

        public IUserContext SetUserClaims(UserClaims userClaims)
        {
            _userClaims = userClaims;
            return this;
        }

        public ConcurrentDictionary<string, string> ConnectedClients { get; } = new ConcurrentDictionary<string, string>();
    }
}
