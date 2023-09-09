﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilizer
{
    public interface IDbConnectionFactory
    {
        NpgsqlConnection CreateConnection();
        Task CreateDbTables();
    }
}