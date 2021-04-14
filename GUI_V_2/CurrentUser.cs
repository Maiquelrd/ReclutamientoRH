using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_V_2
{
    public class CurrentUser
    {
        CD_Commands Connection = new CD_Commands(); 
        private static CurrentUser instance { get; set; }
        public int userID { get; set; }
        public string candidatoID { get; set; }

        public CurrentUser()
        {
            instance = this;
        }
        public CurrentUser(int userID)
        {
            this.userID = userID;
            instance = this;
            this.candidatoID = Connection.getSpecificData("select candidato.Candidato_ID from Candidato inner join Persona on Candidato.Persona_ID = Persona.Persona_ID inner join Usuario on Persona.Persona_ID = Usuario.Persona_ID where usuario.Usuario_ID=" + userID.ToString());
        }

        public static CurrentUser GetInstance()
        {
            return instance;
        } 

    }
}
