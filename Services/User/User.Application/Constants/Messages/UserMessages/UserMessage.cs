﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Constants.Messages.UserMessages
{
    public static class UserMessage
    {
        public const string EmailIsNotValid = "Email is not valid.";
        public const string EmailRequired = "Email is required.";
        public const string FirstNameRequired = "FirstName is required.";
        public const string LastNameRequired = "LastName is required.";
        public const string EmailExceeded = "Email must not exceed 256 characters.";
        public const string FirstNameExceeded = "FirstName must not exceed 128 characters.";
        public const string LastNameExceeded = "LastName must not exceed 128 characters.";
    }
}
