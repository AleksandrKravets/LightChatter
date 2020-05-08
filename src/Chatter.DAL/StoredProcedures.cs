using Quantum.DAL.Infrastructure;
using Quantum.DAL.Infrastructure.Attributes;
using System;

namespace Chatter.DAL.StoredProcedures
{
    namespace Users
    {
        [ProcedureName("GetUser")]
        internal class SPGetUser : StoredProcedure
        {
            [InParameter] public string Email;
            [InParameter] public string Nickname;
        }

        [ProcedureName("CreateUser")]
        internal class SPCreateUser : StoredProcedure
        {
            [InParameter] public string Nickname;
            [InParameter] public string Email;
            [InParameter] public string HashedPassword;
        }

        [ProcedureName("GetUserByEmail")]
        internal class SPGetUserByEmail : StoredProcedure
        {
            [InParameter] public string Email;
        }

        [ProcedureName("GetUserById")]
        internal class SPGetUserById : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("GetUserToken")]
        internal class SPGetUserToken : StoredProcedure
        {
            [InParameter] public long UserId;
        }
    }

    namespace Messages
    {
        [ProcedureName("CreateMessage")]
        internal class SPCreateMessage : StoredProcedure
        {
            [InParameter] public string Text;
            [InParameter] public DateTime CreationTime;
            [InParameter] public long SenderId;
        }

        [ProcedureName("UpdateMessage")]
        internal class SPUpdateMessage : StoredProcedure
        {
            [InParameter] public long Id;
            [InParameter] public DateTime CreationTime;
            [InParameter] public string Text;
        }

        [ProcedureName("DeleteMessage")]
        internal class SPDeleteMessage : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("GetMessage")]
        internal class SPGetMessage : StoredProcedure
        {
            [InParameter] public long Id;
        }

        [ProcedureName("GetMessages")]
        internal class SPGetMessages : StoredProcedure
        {
        }
    }

    namespace Tokens
    {
        [ProcedureName("CreateRefreshToken")]
        internal class SPCreateRefreshToken : StoredProcedure
        {
            [InParameter] public string Token;
            [InParameter] public string JwtId;
            [InParameter] public DateTime CreationDate;
            [InParameter] public DateTime ExpiryDate;
            [InParameter] public long UserId;
        }

        [ProcedureName("UseToken")]
        internal class SPUseToken : StoredProcedure
        {
            [InParameter] public string Token;
        }

        [ProcedureName("GetToken")]
        internal class SPGetToken : StoredProcedure
        {
            [InParameter] public string Token;
        }
    }
}
