using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Model
{
    public class GroupModel : BaseDataModel
    {
        public string ApplicationCode { get; set; }
    }
}