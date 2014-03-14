using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchLookupTable
{
    public class SynchMaster
    {
        public SqlConnection localConnection { get; set; }
        public SqlConnection remoteConnection { get; set; }
        public string actionPerformed { get; set; }
        public SqlCommand cmd { get; set; }

        public SqlConnection conn { get; set; }

        public SynchMaster()
        {

        }

        public void UploadData(SqlConnection localConnection, SqlConnection remoteConnection)
        {
            this.localConnection = localConnection;
            this.remoteConnection = remoteConnection;

            using (cmd){
                cmd.Connection = localConnection;
            }

         
        }
    }
}
