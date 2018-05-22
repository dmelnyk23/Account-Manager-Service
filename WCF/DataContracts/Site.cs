using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.DataContracts
{
    [DataContract]
    public class Site
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual User User { get; set; }

    }
}