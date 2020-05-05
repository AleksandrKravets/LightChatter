using Quantum.DAL.Infrastructure;
using Quantum.DAL.Infrastructure.Attributes;
using System;

namespace Chatter.DAL.StoredProcedures
{
    namespace Users
    {
        [ProcedureName("CreateUser")]
        internal class SPCreateUser : StoredProcedure
        {
            [InParameter] public string Nickname;
            [InParameter] public string Email;
            [InParameter] public string HashedPassword;
            [InParameter] public int RoleId;
        }

        [ProcedureName("GetUserByEmail")]
        internal class SPGetUserByEmail : StoredProcedure
        {
            [InParameter] public string Email;
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
}
