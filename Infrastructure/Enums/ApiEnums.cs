﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    public class ApiEnums
    {
        public enum EntityStatus
        {
            NORMAL = 1,
            OK = 2,
            NOT_OK = 3,
            TEMP = 10,
            LOCK = 98,
            DELETED = 99,
        }
        public enum TypeAction
        {
            VIEW = 0,
            CREATE = 1,
            UPDATE = 2,
            DELETED = 3,
            IMPORT = 4,
            EXPORT = 5,
            PRINT = 6,
            EDIT_ANOTHER_USER = 7,
            MENU = 8,
            LOG_IN = 9,
            LOG_OUT = 10
        }
        public enum TypeSignalRNotify
        {
            LOG_OUT = 1,
            NOTIFY = 2,
            RE_LOGIN = 3
        }
    }
}
