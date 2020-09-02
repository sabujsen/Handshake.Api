using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hskAPI.DAL;
using System.Data.Entity.Migrations;

namespace Model.Entity
{
    public class Database
    {
        public static void seed()
        {
            HandshakeContext context = new HandshakeContext();
            // check if database has data
            // if not then pump in some values
            if (!context.Token_UserTypes.Any(u => u.Name == "merchant"))
            {
                var userTypes = new List<Token_UserType>
            {
                new Token_UserType {Name="consumer"},
                new Token_UserType {Name="merchant"}
            };
                userTypes.ForEach(u => context.Token_UserTypes.AddOrUpdate(p => p.Name, u));
                context.SaveChanges();
            }

            if (!context.Token_Words.Any(u => u.Word == "kangaroo"))
            {
                var tokenWords = new List<Token_Word>
            {
                new Token_Word {Word="ballart"},
                new Token_Word {Word="barramundi"},
                new Token_Word {Word="bilby"},
                new Token_Word {Word="Bindiieye"},
                new Token_Word {Word="bogong"},
                new Token_Word {Word="boobook"},
                new Token_Word {Word="brigalow"},
                new Token_Word {Word="brolga"},
                new Token_Word {Word="budgerigar"},
                new Token_Word {Word="bunyip"},
                new Token_Word {Word="burdardu"},
                new Token_Word {Word="coolibah"},
                new Token_Word {Word="cunjevoi"},
                new Token_Word {Word="curara"},
                new Token_Word {Word="currawong"},
                new Token_Word {Word="dingo"},
                new Token_Word {Word="drongo"},
                new Token_Word {Word="galah"},
                new Token_Word {Word="ganggang"},
                new Token_Word {Word="geebung"},
                new Token_Word {Word="gidgee"},
                new Token_Word {Word="gilgie"},
                new Token_Word {Word="gymea"},
                new Token_Word {Word="jarrah"},
                new Token_Word {Word="joogee"},
                new Token_Word {Word="kangaroo"},
                new Token_Word {Word="koala"},
                new Token_Word {Word="kookaburra"},
                new Token_Word {Word="kurrajong"},
                new Token_Word {Word="kutjera"},
                new Token_Word {Word="mallee"},
                new Token_Word {Word="marri"},
                new Token_Word {Word="mihirung"},
                new Token_Word {Word="mulga"},
                new Token_Word {Word="myall"},
                new Token_Word {Word="numbat"},
                new Token_Word {Word="pademelon"},
                new Token_Word {Word="potoroo"},
                new Token_Word {Word="quandong"},
                new Token_Word {Word="quokka"},
                new Token_Word {Word="quoll"},
                new Token_Word {Word="taipan"},
                new Token_Word {Word="wallaby"},
                new Token_Word {Word="wallaroo"},
                new Token_Word {Word="waratah"},
                new Token_Word {Word="warrigal"},
                new Token_Word {Word="witchetty"},
                new Token_Word {Word="wobbegong"},
                new Token_Word {Word="wombat"},
                new Token_Word {Word="wonga"},
                new Token_Word {Word="wongawonga"},
                new Token_Word {Word="yabby"},
                new Token_Word {Word="pama"},
                new Token_Word {Word="paya"},
                new Token_Word {Word="luwa"},
                new Token_Word {Word="wulya"},
                new Token_Word {Word="mara"},
                new Token_Word {Word="nana"},
                new Token_Word {Word="tura"},
                new Token_Word {Word="pula"},
                new Token_Word {Word="tali"},
                new Token_Word {Word="kati"}
            };
                tokenWords.ForEach(u => context.Token_Words.AddOrUpdate(p => p.Word, u));
                context.SaveChanges();
            }
        }
    }
}