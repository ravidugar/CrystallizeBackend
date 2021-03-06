﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    /// <summary>
    /// Different type of operations supported by DynamoDB
    /// </summary>
    public enum Operator
    {
        EQ,             // ==
        NE,             // !=
        LE,             // <=
        LT,             // <
        GE,             // >=
        GT,             // >
        NOT_NULL,
        NULL,
        CONTAINS,
        NOT_CONTAINS,
        BEGINS_WITH,
        IN,
        BETWEEN
    }
}
