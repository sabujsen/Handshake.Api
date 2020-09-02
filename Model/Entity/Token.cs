using hskAPI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace Model.Entity
{
    public class Token
    {
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int RecordId { get; set; }
        [Required]
        public string Value { get; set; }
    }

    public class Token_UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static int getTypeId(string TypeName)
        {
            int theId = 0;
            string typeName = TypeName.ToLower();
            HandshakeContext context = new HandshakeContext();
            if (!context.Token_UserTypes.Any(u => u.Name == typeName))
            {
                Token_UserType userType = new Token_UserType();
                userType.Name = typeName;
                context.Token_UserTypes.AddOrUpdate(p => p.Name, userType);
                context.SaveChanges();
            }
            theId = context.Token_UserTypes.First(u => u.Name == typeName).Id;
            return theId;
        }
    }

    public class Token_Word
    {
        public int Id { get; set; }
        public string Word { get; set; }
    }
}