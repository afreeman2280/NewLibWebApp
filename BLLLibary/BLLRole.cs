using System;
using System.Collections.Generic;
using System.Text;
using CommonLib;
using DALLib;

namespace BLLibary
{
    public class BLLRole
    {
        int ID;
        string RoleName;
        Role bLLRole;

        public BLLRole()
        {
            this.ID = 1;
            this.RoleName = "Guest";
        }
        public BLLRole(int iD, string roleName)
        {
            ID = iD;
            RoleName = roleName;
        }
        public string getRole(int iD)
        {
            DARole dARole = new DARole();   
           bLLRole= dARole.GetRole(iD);
            return bLLRole.RoleName;
        }
      
    }
}
