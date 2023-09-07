using BusinessModels;
using Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD_Motor_Service
{
    public class ReaderItems
    {
        private IEnumerable<Session> _sessions;
        private IUserSessionService _userSessionService;
        private ILogger _logger;
        public ReaderItems(IUserSessionService userSessionService, ILogger<ReaderItems> logger)
        {
            _userSessionService = userSessionService ?? throw new ArgumentNullException(nameof(userSessionService));
            _logger = logger;
            ReadSessionData();
        }

        private async Task<IEnumerable<Session>> ReadSessionData()
        {
            return await _userSessionService.GetSessions();
        }

    }
}
